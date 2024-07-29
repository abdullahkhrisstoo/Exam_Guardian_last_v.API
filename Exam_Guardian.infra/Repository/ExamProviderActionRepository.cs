using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Exam_Guardian.infra.Repository
{
    public class ExamProviderActionRepository : IExamProviderActionRepository
    {
        private readonly ModelContext _context;

        public ExamProviderActionRepository(ModelContext context)
        {
            _context = context;
        }
        public async Task<int> CreateExamProviderAction(CreateExamProviderActionDTO createComplementViewModel)
        {
           await _context.AddAsync(new ExamProviderAction
            {
               ActionName=createComplementViewModel.ActionName,

            });
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteExamProviderAction(int id)
        {
            var entity = await _context.ExamProviderActions.FindAsync(id);
            if (entity == null) return 0;

            _context.ExamProviderActions.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExamProviderActionDTO>> GetAllExamProviderActions()
        {
            return await _context.ExamProviderActions.Select(e => new ExamProviderActionDTO
            {

                ExamProviderActionId = e.ExamProviderActionId,
                ActionName = e.ActionName

            }).ToListAsync();
        }

        public async Task<ExamProviderActionDTO> GetExamProviderActionById(int id)
        {
            var action= await _context.ExamProviderActions.Select(e => new ExamProviderActionDTO
            {

                ExamProviderActionId = e.ExamProviderActionId,
                ActionName = e.ActionName

            }).FirstOrDefaultAsync(e => e.ExamProviderActionId == id); ;
            if (action is null) {
                throw new Exception("action not found");
            }
            return action;


        }

        public async Task<int> UpdateExamProviderAction(UpdateExamProviderActionDTO updateComplementViewModel)
        {
            _context.ExamProviderActions.Update(new ExamProviderAction { 
            ActionName = updateComplementViewModel.ActionName,
            ExamProviderActionId = updateComplementViewModel.ExamProviderActionId
            });
            return await _context.SaveChangesAsync();
        }
    }
}
