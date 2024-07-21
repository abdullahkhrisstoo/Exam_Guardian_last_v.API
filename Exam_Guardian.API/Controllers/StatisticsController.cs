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
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStatistics()
        {
            try
            {
                var result = await _statisticsService.GetAllStatistics();
                if (result == null)
                {
                    return this.ApiResponseNotFound("Statistics not found", new { });
                }
                return this.ApiResponseOk("Statistics retrieved successfully", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }
    }

}
