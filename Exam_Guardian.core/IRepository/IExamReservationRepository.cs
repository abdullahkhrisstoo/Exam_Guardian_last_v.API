﻿using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IRepository
{
    public interface IExamReservationRepository
    {
        Task<int> CreateExamReservation(CreateExamReservationDTO createExamReservationViewModel);
        Task<int> DeleteExamReservation(int id);
        Task<int> UpdateExamReservation(UpdateExamReservationDTO updateExamReservationViewModel);
        Task<ExamReservationDTO> GetExamReservationById(int id);
        Task<IEnumerable<ExamReservationDTO>> GetAllExamReservations();
        Task<IEnumerable<TimeSlotsViewModel>> GetTimeSlots();
        Task<IEnumerable<ExamReservation>> GetExamReservationDependsProctor();
        Task<IEnumerable<ExamReservationDTO>> GetAllExamReservationsByExamId(decimal examId);
      
        Task<IEnumerable<ExamReservationProctorDTO>> GetAllExamReservationsByProctorId(decimal userId);

        Task<IEnumerable<AvailableTimeDTO>> GetAvailableTimesByDate(DateTime dateTime, int duration, bool is24HourFormat);
        Task<IEnumerable<ExamReservationDetailsDTO>> GetAllExamReservationsDetails();
        Task<IEnumerable<ExamReservationDetailsDTO>> GetAllExamReservationsDetailsBy(string studentName);
         Task<List<ProctorReservationDTO>> GetAvailableProctors(DateTime StartTime, DateTime EndTime, DateTime ReservationDate);
    }

}
