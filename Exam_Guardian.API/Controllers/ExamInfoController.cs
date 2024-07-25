using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Exam_Guardian.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Guardian.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamInfoController : ControllerBase
    {

        private readonly IExamInfoService _examInfoService;

        public ExamInfoController(IExamInfoService examInfoService)
        {
            _examInfoService = examInfoService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponseModel<ExamInfoDTO>>> CreateExam([FromBody] CreateExamInfoDTO createExamDto)
        {
            var exam = await _examInfoService.CreateExamAsync(createExamDto);
            var response = new ApiResponseModel<ExamInfoDTO>
            {
                Message = "Exam created successfully",
                Status = 201,
                Data = exam
            };
            return CreatedAtAction(nameof(GetExamById), new { id = exam.ExamId }, response);
        }

 
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponseModel<ExamInfoDTO>>> GetExamById(decimal id)
        {
            var exam = await _examInfoService.GetExamByIdAsync(id);
            if (exam == null)
            {
                return NotFound(new ApiResponseModel<ExamInfoDTO>
                {
                    Message = "Exam not found",
                    Status = 404,
                    Data = null
                });
            }
            return Ok(new ApiResponseModel<ExamInfoDTO>
            {
                Message = "Exam retrieved successfully",
                Status = 200,
                Data = exam
            });
        }


        [HttpPut]
        public async Task<ActionResult<ApiResponseModel<bool>>> UpdateExam( [FromBody] UpdateExamInfoDTO updateExamDto)
        {
        

            var result = await _examInfoService.UpdateExamAsync(updateExamDto);
            if (!result)
            {
                return NotFound(new ApiResponseModel<bool>
                {
                    Message = "Exam not found",
                    Status = 404,
                    Data = false
                });
            }

            return Ok(new ApiResponseModel<bool>
            {
                Message = "Exam updated successfully",
                Status = 200,
                Data = true
            });
        }

    
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponseModel<bool>>> DeleteExam(decimal id)
        {
            var result = await _examInfoService.DeleteExamAsync(id);
            if (!result)
            {
                return NotFound(new ApiResponseModel<bool>
                {
                    Message = "Exam not found",
                    Status = 404,
                    Data = false
                });
            }

            return Ok(new ApiResponseModel<bool>
            {
                Message = "Exam deleted successfully",
                Status = 200,
                Data = true
            });
        }

        [HttpGet("{examProviderId}")]
        public async Task<ActionResult<ApiResponseModel<IEnumerable<ExamInfoDTO>>>> GetExamsByProvider(decimal examProviderId)
        {
            var exams = await _examInfoService.GetExamsByExamProviderIdAsync(examProviderId);
            return Ok(new ApiResponseModel<IEnumerable<ExamInfoDTO>>
            {
                Message = "Exams retrieved successfully",
                Status = 200,
                Data = exams
            });
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponseModel<IEnumerable<ExamInfoDTO>>>> GetAllExams()
        {
            var exams = await _examInfoService.GetAllExams();
            return Ok(new ApiResponseModel<IEnumerable<ExamInfoDTO>>
            {
                Message = "Exams retrieved successfully",
                Status = 200,
                Data = exams
            });
        }



        
    }
}
