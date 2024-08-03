using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IRepository
{
    public class ReservationInvoiceRepository : IReservationInvoiceRepository
    {
        private readonly ModelContext _context;

        public ReservationInvoiceRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<int> CreateReservationInvoice(CreateReservationInvoiceDTO createDto)
        {
            var entity = new ReservationInvoice
            {
                ExamReservationId = createDto.ExamReservationId,
                Value = createDto.Value,
     
            };

            await _context.ReservationInvoices.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteReservationInvoice(decimal id)
        {
            var entity = await _context.ReservationInvoices.FindAsync(id);
            if (entity == null) return 0;

            _context.ReservationInvoices.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateReservationInvoice(UpdateReservationInvoiceDTO updateDto)
        {
            var entity = await _context.ReservationInvoices.FindAsync(updateDto.ReservationInvoiceId);
            if (entity == null) return 0;

            entity.ExamReservationId = updateDto.ExamReservationId;
            entity.Value = updateDto.Value;
   

            _context.ReservationInvoices.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<ReservationInvoiceDTO> GetReservationInvoiceById(decimal id)
        {
            var entity = await _context.ReservationInvoices.FindAsync(id);
            if (entity == null) throw new Exception("Reservation invoice not found");

            return new ReservationInvoiceDTO
            {
                ReservationInvoiceId = entity.ReservationInvoiceId,
                ExamReservationId = entity.ExamReservationId,
                Value = entity.Value,
                CreatedAt = entity.CreatedAt
            };
        }

        public async Task<IEnumerable<ReservationInvoiceDTO>> GetAllReservationInvoices()
        {
            return await _context.ReservationInvoices.Select(e => new ReservationInvoiceDTO
            {
                ReservationInvoiceId = e.ReservationInvoiceId,
                ExamReservationId = e.ExamReservationId,
                Value = e.Value,
                CreatedAt = e.CreatedAt
            }).ToListAsync();
        }

        public async Task<IEnumerable<ReservationInvoiceDetailsDTO>> GetAllReservationInvoicesDetails()
        {
            return await _context.ReservationInvoices.Include(e=>e.ExamReservation)
                .Select(e => new ReservationInvoiceDetailsDTO
            {
                ExamName=e.ExamReservation.Exam.ExamTitle,
                StudentEmail=e.ExamReservation.Email,
                StudentName=e.ExamReservation.StudentName,
                Value = e.Value,
                CreatedAt = e.CreatedAt,
                ExamProviderName=e.ExamReservation.Exam.ExamProvider.User.FirstName

            }).ToListAsync();
        }

    }

}
