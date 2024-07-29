using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Repository
{
    public class ExamProviderLinkRepository : IExamProviderLinkRepository
    {
        private readonly ModelContext _context;

        public ExamProviderLinkRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<int> CreateExamProviderLink(CreateExamProviderLinkDTO createDto)
        {
            var entity = new ExamProviderLink
            {
                LinkPath = createDto.LinkPath,
                ExamProviderId = createDto.ExamProviderId,
                ActionId = createDto.ActionId
            };

            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteExamProviderLink(int id)
        {
            var entity = await _context.ExamProviderLinks.FindAsync(id);
            if (entity == null) return 0;

            _context.ExamProviderLinks.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateExamProviderLink(UpdateExamProviderLinkDTO updateDto)
        {
            var entity = await _context.ExamProviderLinks.FindAsync(updateDto.ExamProviderLinkId);
            if (entity == null) return 0;

            entity.LinkPath = updateDto.LinkPath;
            entity.ExamProviderId = updateDto.ExamProviderId;
            entity.ActionId = updateDto.ActionId;

            _context.ExamProviderLinks.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<ExamProviderLinkDTO> GetExamProviderLinkById(int id)
        {
            var entity = await _context.ExamProviderLinks.FindAsync(id);
            if (entity == null) throw new Exception("Link not found");

            return new ExamProviderLinkDTO
            {
                ExamProviderLinkId = entity.ExamProviderLinkId,
                LinkPath = entity.LinkPath,
                ExamProviderId = entity.ExamProviderId,
                ActionId = entity.ActionId
            };
        }

        public async Task<IEnumerable<ExamProviderLinkDTO>> GetAllExamProviderLinks()
        {
            return await _context.ExamProviderLinks.Select(e => new ExamProviderLinkDTO
            {
                ExamProviderLinkId = e.ExamProviderLinkId,
                LinkPath = e.LinkPath,
                ExamProviderId = e.ExamProviderId,
                ActionId = e.ActionId
            }).ToListAsync();
        }

        public async Task<IEnumerable<ExamProviderLinkDTO>> GetExamProviderLinkByCompanyAndActionName(string companyName, string actionName)
        {
            return await _context.ExamProviderLinks
                .Include(e => e.ExamProvider).
                 ThenInclude(e=>e.User)
                .Include(e => e.Action)
                .Where(e => e.Action!=null && e.ExamProvider!=null &&
                e.ExamProvider.User != null && e.ExamProvider.User.FirstName == companyName 
                && e.Action.ActionName == actionName)
                .Select(e => new ExamProviderLinkDTO
                {
                    ExamProviderLinkId = e.ExamProviderLinkId,
                    LinkPath = e.LinkPath,
                    ExamProviderId = e.ExamProviderId,
                    ActionId = e.ActionId
                }).ToListAsync();
        }


        public async Task<IEnumerable<ExamProviderLinkDTO>> GetExamProviderLinkByCompany(string companyName)
        {
            return await _context.ExamProviderLinks
                .Include(e => e.ExamProvider).
                 ThenInclude(e => e.User)
                .Include(e => e.Action)
                .Where(e => e.Action != null && e.ExamProvider != null &&
                e.ExamProvider.User != null && e.ExamProvider.User.FirstName == companyName).OrderBy(e=>e.ActionId)
                .Select(e => new ExamProviderLinkDTO
                {
                    ExamProviderLinkId = e.ExamProviderLinkId,
                    LinkPath = e.LinkPath,
                    ExamProviderId = e.ExamProviderId,
                    ActionId = e.ActionId,
                    ActionName=e.Action.ActionName
                   
                }).ToListAsync();
        }


    }


}
