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
    public class PlanInvoiceRepository : IPlanInvoiceRepository
    {
        private readonly ModelContext _context;

        public PlanInvoiceRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePlanInvoice(CreatePlanInvoiceDTO createDto)
        {
            var entity = new PlanInvoice
            {
                Value = createDto.Value,
                PlanId = createDto.PlanId,
                ExamProviderId = createDto.ExamProviderId,
        
            };

            await _context.PlanInvoices.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePlanInvoice(decimal id)
        {
            var entity = await _context.PlanInvoices.FindAsync(id);
            if (entity == null) return 0;

            _context.PlanInvoices.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePlanInvoice(UpdatePlanInvoiceDTO updateDto)
        {
            var entity = await _context.PlanInvoices.FindAsync(updateDto.PlanInvoiceId);
            if (entity == null) return 0;

            entity.Value = updateDto.Value;
            entity.PlanId = updateDto.PlanId;
            entity.ExamProviderId = updateDto.ExamProviderId;
           

            _context.PlanInvoices.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<PlanInvoiceDTO> GetPlanInvoiceById(decimal id)
        {
            var entity = await _context.PlanInvoices.FindAsync(id);
            if (entity == null) throw new Exception("Plan invoice not found");

            return new PlanInvoiceDTO
            {
                PlanInvoiceId = entity.PlanInvoiceId,
                Value = entity.Value,
                PlanId = entity.PlanId,
                ExamProviderId = entity.ExamProviderId,
                CreatedAt = entity.CreatedAt
            };
        }

        public async Task<IEnumerable<PlanInvoiceDTO>> GetAllPlanInvoices()
        {
            return await _context.PlanInvoices.Select(e => new PlanInvoiceDTO
            {
                PlanInvoiceId = e.PlanInvoiceId,
                Value = e.Value,
                PlanId = e.PlanId,
                ExamProviderId = e.ExamProviderId,
                CreatedAt = e.CreatedAt
            }).ToListAsync();
        }

        public async Task<IEnumerable<PlanInvoiceDetailsDTO>> GetAllPlanInvoicesDetails()
        {
            return await _context.PlanInvoices
                .Include(e=>e.ExamProvider)
                .Include(e=>e.Plan)
                .Select(e => new PlanInvoiceDetailsDTO
                {
           
                Value = e.Value,
                ExamProviderName=e.ExamProvider.User.FirstName,
                PlanName=e.Plan.PlanName,
                CreatedAt = e.CreatedAt
            }).ToListAsync();
        }
    }

}
