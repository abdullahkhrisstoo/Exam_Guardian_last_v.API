using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class TestimonalService : ITestimonalService
    {
        private readonly ITestimonalRepositary _testimonalRepositary;

        public TestimonalService(ITestimonalRepositary testimonalRepositary)
        {
            _testimonalRepositary = testimonalRepositary;
        }

        public async Task CreateTestimonialAsync(TestimonalModel testimonial)
        {
           await _testimonalRepositary.CreateTestimonialAsync(testimonial);
        }

        public async Task DeleteTestimonialAsync(decimal id)
        {
            await _testimonalRepositary.DeleteTestimonialAsync(id);
        }

        public async Task<IEnumerable<GetTestimonialViewModel>> GetAllApprovedTestimonialsAsync()
        {
            return await _testimonalRepositary.GetAllApprovedTestimonialsAsync();
        }

        public async Task<IEnumerable<GetTestimonialViewModel>> GetAllRejectedTestimonialsAsync()
        {
            return await _testimonalRepositary.GetAllRejectedTestimonialsAsync();
        }

        public async Task<IEnumerable<GetTestimonialViewModel>> GetAllTestimonialsAsync()
        {
            return await _testimonalRepositary.GetAllTestimonialsAsync();
        }

        public async Task<IEnumerable<GetTestimonialViewModel>> GetPendingTestimonialsAsync()
        {
            return await _testimonalRepositary.GetPendingTestimonialsAsync();
        }

        public async Task<GetTestimonialViewModel> GetTestimonialByIdAsync(int id)
        {
            return await _testimonalRepositary.GetTestimonialByIdAsync(id);
        }
    }
}
