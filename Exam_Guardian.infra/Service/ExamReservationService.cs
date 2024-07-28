﻿using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class ExamReservationService : IExamReservationService
    {
        private readonly IExamReservationRepository _examReservationRepository;

        public ExamReservationService(IExamReservationRepository examReservationRepository)
        {
            _examReservationRepository = examReservationRepository;
        }

        public async Task<int> CreateExamReservation(CreateExamReservationDTO createExamReservationViewModel)
        {
            return await _examReservationRepository.CreateExamReservation(createExamReservationViewModel);
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

      
    }


}














