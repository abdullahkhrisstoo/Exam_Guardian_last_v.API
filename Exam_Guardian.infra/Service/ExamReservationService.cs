using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using Exam_Guardian.infra.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class ExamReservationService : IExamReservationService
    {
        private readonly IExamReservationRepository _examReservationRepository;
        private readonly IExamInfoRepository _examInfoRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IEmailService _emailService;
        private readonly IReservationInvoiceService _reservationInvoiceService;

        public ExamReservationService(IExamReservationRepository examReservationRepository,
            IExamInfoRepository examInfoRepository, ICardRepository cardRepository,
            IEmailService emailService,
            IReservationInvoiceService reservationInvoiceService)
        {
            _examReservationRepository = examReservationRepository;
            _examInfoRepository = examInfoRepository;
            _cardRepository = cardRepository;
            _emailService = emailService;
            _reservationInvoiceService = reservationInvoiceService;


        }

        public async Task<int> CreateExamReservation(CreateExamReservationDTO createExamReservationViewModel)
        {
            return await _examReservationRepository.CreateExamReservation(createExamReservationViewModel);
        }


        public async Task<int> CreateProcessExamReservation(ExamReservationPaymentDTO examReservationPaymentDTO)
        {

            var availableTimes = await GetAvailableTimesByDate(examReservationPaymentDTO.ReservationDate, examReservationPaymentDTO.ExamDuration, false);
            var isExamResevartionAvaliable = availableTimes
                .Any(e => e.StartTime == examReservationPaymentDTO.StartTime
            && e.EndTime == examReservationPaymentDTO.EndTime);

            if (isExamResevartionAvaliable is false)
            {
                throw new Exception("exam reservation is not avaliable");
            }
            var exam = await _examInfoRepository.GetExamByExamName(examReservationPaymentDTO.ExamName);
            if (exam == null)
            {

                throw new Exception("exam not found");
            }


            var isSuccuss = await _cardRepository.WithdrawFromCard(new WithdrawCardDTO
            {
                CardInfoDTO = examReservationPaymentDTO.CardInfoDTO,
                AmountWithDraw = examReservationPaymentDTO.Price
            });

            var avaliableProctors = await _examReservationRepository
                .GetAvailableProctors(examReservationPaymentDTO.StartTime,
                examReservationPaymentDTO.EndTime,
                examReservationPaymentDTO.ReservationDate);

          
            Random random = new Random();
            int randomIndex = random.Next(avaliableProctors.Count);
            var randomProctor = avaliableProctors[randomIndex];


            var proctorToken = Guid.NewGuid().ToString();
            var studentToken = Guid.NewGuid().ToString();
          
            int reservationId= await _examReservationRepository.CreateExamReservation(new CreateExamReservationDTO
            {
                EndDate = examReservationPaymentDTO.EndTime,
                StartDate = examReservationPaymentDTO.StartTime,
                StudentName = examReservationPaymentDTO.StudentName,
                ProctorTokenEmail = proctorToken,
                StudentTokenEmail = studentToken,
                UserId= randomProctor.UserId,
                ExamId=exam.ExamId,
                Email=examReservationPaymentDTO.StudentEmail,
                });

            await _reservationInvoiceService.CreateReservationInvoice(new CreateReservationInvoiceDTO()
            {
                ExamReservationId= reservationId,
                Value= examReservationPaymentDTO.Price
            });


            string proctorActionLink = $"https://localhost:1111/api/examReservation/GetExamDashToProctor?token={proctorToken}&reservationId={reservationId}";
            string studentActionLink = $"https://localhost:1111/api/examReservation/GetExamDashToStudent?token={studentToken}&reservationId={reservationId}";

            string formattedReservationDate = examReservationPaymentDTO.ReservationDate.ToString("MMMM dd, yyyy");
            string formattedStartTime = examReservationPaymentDTO.StartTime.ToString(@"hh\:mm");
            string formattedEndTime = examReservationPaymentDTO.EndTime.ToString(@"hh\:mm");

            var studentReservationHtml = HtmlContentGenerator.GenerateStudentReservationConfirmationEmail(
            examReservationPaymentDTO.StudentName,
            examReservationPaymentDTO.ExamName,
            formattedReservationDate,
            formattedStartTime,
            formattedEndTime,
            studentActionLink);

            // Generate reservation invoice email for the student
            var studentInvoiceHtml = HtmlContentGenerator.GenerateStudentReservationInvoiceEmail(
                examReservationPaymentDTO.StudentName,
                examReservationPaymentDTO.ExamName,
               formattedReservationDate,
               formattedStartTime,
               formattedStartTime,
                examReservationPaymentDTO.Price);

            // Generate proctor notification email
            var proctorNotificationHtml = HtmlContentGenerator.GenerateProctorNotificationEmail(
                randomProctor.FirstName,
                examReservationPaymentDTO.ExamName,
                formattedReservationDate,
                formattedStartTime,
                formattedEndTime,
                proctorActionLink);

            await _emailService.SendEmail(new SendEmailViewModel
            {
                Title = "Proctor Notification",
                Body = proctorNotificationHtml,
                Receiver = randomProctor.Email,
                IsHtml = true
            });
            await _emailService.SendEmail(new SendEmailViewModel
            {
                Title = "Exam Invoice",
                Body = studentInvoiceHtml,
                Receiver = examReservationPaymentDTO.StudentEmail,
                IsHtml = true
            });
            await _emailService.SendEmail(new SendEmailViewModel
            {
                Title = "Exam Reservation Successful",
                Body = studentReservationHtml,
                Receiver = examReservationPaymentDTO.StudentEmail,
                IsHtml = true

            });

            return 1;

        }


        public async Task<int> DeleteExamReservation(int id)
        {
            return await _examReservationRepository.DeleteExamReservation(id);
        }

        public async Task<int> UpdateExamReservation(UpdateExamReservationDTO updateExamReservationViewModel)
        {
            return await _examReservationRepository.UpdateExamReservation(updateExamReservationViewModel);
        }

        public async Task<ExamReservationDTO> GetExamReservationById(int id)
        {
            return await _examReservationRepository.GetExamReservationById(id);
        }

        public async Task<IEnumerable<ExamReservationDTO>> GetAllExamReservations()
        {
            return await _examReservationRepository.GetAllExamReservations();
        }
        //todo:
        public async Task<IEnumerable<UnavailableTimeViewModel>> GetTimeSlot()
        {
            var timeSlots = await _examReservationRepository.GetTimeSlots();

            var allTimeSlots = new List<TimeSlotsViewModel>();

            foreach (var slot in timeSlots)
            {
                var splitTimeSlots = SplitTimeSlot(slot);

                allTimeSlots.AddRange(splitTimeSlots);
            }
            var aggregatedTimeSlots = AggregateTimeSlot(allTimeSlots);


            List<UnavailableTimeViewModel> unavailableTimeList = new List<UnavailableTimeViewModel>();
            foreach (var i in aggregatedTimeSlots)
            {
                if (i.ReservationCount >= i.ProctorCount)
                {
                    unavailableTimeList.Add(new UnavailableTimeViewModel
                    {
                        SartDate = i.SartDate!,
                        EndDate = i.EndDate!
                    });
                }
            }

            return unavailableTimeList;
        }

        private IEnumerable<TimeSlotsViewModel> SplitTimeSlot(TimeSlotsViewModel slot)
        {
            DateTime startDate = DateTime.ParseExact(slot?.SartDate!, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(slot?.EndDate!, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            if ((endDate - startDate).TotalHours >= 2)
            {
                DateTime midPoint = startDate.AddHours(1);

                TimeSlotsViewModel firstSlot = new TimeSlotsViewModel
                {
                    ProctorCount = slot.ProctorCount,
                    ReservationCount = slot.ReservationCount,
                    SartDate = startDate.ToString("dd-MM-yyyy HH:mm:ss"),
                    EndDate = midPoint.ToString("dd-MM-yyyy HH:mm:ss")
                };

                TimeSlotsViewModel secondSlot = new TimeSlotsViewModel
                {
                    ProctorCount = slot.ProctorCount,
                    ReservationCount = slot.ReservationCount,
                    SartDate = midPoint.ToString("dd-MM-yyyy HH:mm:ss"),
                    EndDate = endDate.ToString("dd-MM-yyyy HH:mm:ss")
                };

                return new List<TimeSlotsViewModel> { firstSlot, secondSlot };
            }
            else
            {
                return new List<TimeSlotsViewModel> { slot! };
            }
        }

        private IEnumerable<TimeSlotsViewModel> AggregateTimeSlot(IEnumerable<TimeSlotsViewModel> timeSlots)
        {
            var parsedTimeSlots = timeSlots.Select(ts => new
            {
                ProctorCount = ts.ProctorCount,
                ReservationCount = ts.ReservationCount,
                StartDate = DateTime.ParseExact(ts.SartDate!, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact(ts.EndDate!, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture)
            });

            var groupedSlots = parsedTimeSlots
                .GroupBy(ts => new { ts.StartDate, ts.EndDate })
                .Select(group =>
                {
                    return new TimeSlotsViewModel
                    {
                        ProctorCount = group.First().ProctorCount,
                        ReservationCount = group.Sum(ts => ts.ReservationCount),
                        SartDate = group.Key.StartDate.ToString("dd-MM-yyyy HH:mm:ss"),
                        EndDate = group.Key.EndDate.ToString("dd-MM-yyyy HH:mm:ss")
                    };
                })
                .ToList();

            return groupedSlots;
        }


        public Task<IEnumerable<ExamReservation>> GetExamReservationDependsProctor()
        {
            return _examReservationRepository.GetExamReservationDependsProctor();
        }

        


        public async Task<IEnumerable<ExamReservationDTO>> GetAllExamReservationsByExamId(decimal examId)
        {
            return await _examReservationRepository.GetAllExamReservationsByExamId(examId);
        }

        public async Task<IEnumerable<ExamReservationProctorDTO>> GetAllExamReservationsByProctorId(decimal userId)
        {
            return await _examReservationRepository.GetAllExamReservationsByProctorId(userId);
        }

        public async Task<IEnumerable<AvailableTimeDTO>> GetAvailableTimesByDate(DateTime dateTime, int duration, bool is24HourFormat)
        {
            return await _examReservationRepository.GetAvailableTimesByDate(dateTime , duration, is24HourFormat);

        }

        public async Task<IEnumerable<ExamReservationDetailsDTO>> GetAllExamReservationsDetails()
        {
            return await _examReservationRepository.GetAllExamReservationsDetails();
        }

        public async Task<IEnumerable<ExamReservationDetailsDTO>> GetAllExamReservationsDetailsBy(string studentName)
        {
            return await _examReservationRepository.GetAllExamReservationsDetailsBy(studentName);
        }
    }


}














