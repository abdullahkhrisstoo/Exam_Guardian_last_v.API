using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class ExamInfoService: IExamInfoService
    {
        private readonly IExamInfoRepository _examInfoRepository;

        public ExamInfoService(IExamInfoRepository examRepository)
        {
            _examInfoRepository = examRepository;
        }

        public async Task<ExamInfoDTO> CreateExamAsync(CreateExamInfoDTO createExamDto)
        {
            return await _examInfoRepository.CreateExamAsync(createExamDto);
        }

        public async Task<ExamInfoDTO> GetExamByIdAsync(decimal examId)
        {
            return await _examInfoRepository.GetExamByIdAsync(examId);
        }

        public async Task<bool> UpdateExamAsync(UpdateExamInfoDTO updateExamDto)
        {
            return await _examInfoRepository.UpdateExamAsync(updateExamDto);
        }

        public async Task<bool> DeleteExamAsync(decimal examId)
        {
            return await _examInfoRepository.DeleteExamAsync(examId);
        }

        public async Task<IEnumerable<ExamInfoDTO>> GetExamsByExamProviderIdAsync(decimal examProviderId)
        {
            return await _examInfoRepository.GetExamsByExamProviderIdAsync(examProviderId);
        }

        public async Task<IEnumerable<ExamInfoDTO>> GetAllExams()
        {
            return await _examInfoRepository.GetAllExams();
        }
    }

}
