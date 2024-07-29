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
    public class ExamInfoRepository: IExamInfoRepository
    {
        private readonly ModelContext _context;

        public ExamInfoRepository(ModelContext context)
        {
            _context = context;
        }

    
        public async Task<ExamInfoDTO> CreateExamAsync(CreateExamInfoDTO createExamDto)
        {
            var exam = new ExamInfo
            {
                ExamTitle = createExamDto.ExamTitle,
                ExamImage = createExamDto.ExamImage,
                CreatedAt = createExamDto.CreatedAt ?? DateTime.UtcNow,
                UpdatedAt = createExamDto.UpdatedAt ?? DateTime.UtcNow,
                ExamProviderId = createExamDto.ExamProviderId
            };

            _context.ExamInfos.Add(exam);
            await _context.SaveChangesAsync();

            return new ExamInfoDTO
            {
                ExamId = exam.ExamId,
                ExamTitle = exam.ExamTitle,
                ExamImage = exam.ExamImage,
                CreatedAt = exam.CreatedAt,
                UpdatedAt = exam.UpdatedAt,
                ExamProviderId = exam.ExamProviderId
            };
        }

    
        public async Task<ExamInfoDTO> GetExamByIdAsync(decimal examId)
        {
            var exam = await _context.ExamInfos.FindAsync(examId);

            if (exam == null)
                return null;

            return new ExamInfoDTO
            {
                ExamId = exam.ExamId,
                ExamTitle = exam.ExamTitle,
                ExamImage = exam.ExamImage,
                CreatedAt = exam.CreatedAt,
                UpdatedAt = exam.UpdatedAt,
                Price = exam.Price,
                ExamProviderId = exam.ExamProviderId
            };
        }

     
        public async Task<bool> UpdateExamAsync(UpdateExamInfoDTO updateExamDto)
        {
            var exam = await _context.ExamInfos.FindAsync(updateExamDto.ExamId);

            if (exam == null)
                return false;

            exam.ExamTitle = updateExamDto.ExamTitle ?? exam.ExamTitle;
            exam.ExamImage = updateExamDto.ExamImage ?? exam.ExamImage;
            exam.CreatedAt = updateExamDto.CreatedAt ?? exam.CreatedAt;
            exam.UpdatedAt = updateExamDto.UpdatedAt ?? DateTime.UtcNow;
            exam.Price = updateExamDto.Price ?? exam.Price;
            exam.ExamProviderId = updateExamDto.ExamProviderId ?? exam.ExamProviderId;

            _context.ExamInfos.Update(exam);
            await _context.SaveChangesAsync();

            return true;
        }

    
        public async Task<bool> DeleteExamAsync(decimal examId)
        {
            var exam = await _context.ExamInfos.FindAsync(examId);

            if (exam == null)
                return false;

            _context.ExamInfos.Remove(exam);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<IEnumerable<ExamInfoDTO>> GetExamsByExamProviderIdAsync(decimal examProviderId)
        {
            return await _context.ExamInfos
                .Where(e => e.ExamProviderId == examProviderId)
                .Select(e => new ExamInfoDTO
                {
                    ExamId = e.ExamId,
                    ExamTitle = e.ExamTitle,
                    ExamImage = e.ExamImage,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt,
                    Price = e.Price,
                    ExamProviderId = e.ExamProviderId
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<ExamInfoDTO>> GetAllExams()
        {
            return await _context.ExamInfos
             
                .Select(e => new ExamInfoDTO
                {
                    ExamId = e.ExamId,
                    ExamTitle = e.ExamTitle,
                    ExamImage = e.ExamImage,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt,
                    Price= e.Price,
                    ExamProviderId = e.ExamProviderId
                })
                .ToListAsync();
        }

        public async Task<ExamInfoDTO> GetExamByExamName(string examName)
        {
            var examInfo = await _context.ExamInfos
                .Where(e => e.ExamTitle == examName)
                .Select(e => new ExamInfoDTO
                {
                    ExamId = e.ExamId,
                    ExamTitle = e.ExamTitle,
                    ExamImage = e.ExamImage,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt,
                    Price=e.Price,
                    ExamProviderId = e.ExamProviderId
                })
                .FirstOrDefaultAsync();

            if (examInfo == null)
            {
              
                throw new KeyNotFoundException($"Exam with title '{examName}' not found.");
              
            }

            return examInfo;
        }
    }
}
