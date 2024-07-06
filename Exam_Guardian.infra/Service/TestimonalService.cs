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

        public async Task<int> CreateTestimonal(TestimonalModel testimonial)
        {
           return await _testimonalRepositary.CreateTestimonal(testimonial);
        }

        public async Task DeleteTestimonal(decimal id)
        {
            await _testimonalRepositary.DeleteTestimonal(id);
        }

        public async Task<IEnumerable<Testimonial>> GetAllApprovedTestimonal()
        {
            return await _testimonalRepositary.GetAllApprovedTestimonal();
        }

        public async Task<IEnumerable<Testimonial>> GetAllRejectedTestimoanl()
        {
            return await _testimonalRepositary.GetAllRejectedTestimoanl();
        }

        public  async Task<IEnumerable<Testimonial>> GetAllTestimonal()
        {
            return await _testimonalRepositary.GetAllTestimonal();
        }

        public async Task<IEnumerable<Testimonial>> GetAllTestimonals(int? stateId = null, int? testimonialId = null)
        {
            return await _testimonalRepositary.GetAllTestimonals(stateId, testimonialId);
        }

        public  async Task<Testimonial> GetTestimonialById(int id)
        {
            return await _testimonalRepositary.GetTestimonialById(id);
        }
    }
}
