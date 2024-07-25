using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public async Task CreateTestimonialAsync(CreateTestimonailDTO testimonial)
        {
            await _testimonalRepositary.CreateTestimonialAsync(testimonial);
        }

        public async Task DeleteTestimonialAsync(decimal id)
        {
            await _testimonalRepositary.DeleteTestimonialAsync(id);
        }

        public async Task<IEnumerable<TestimonialDTO>> GetAllTestimonials()
        {
            return await _testimonalRepositary.GetAllTestimonials();
        }

        public async Task<TestimonialDTO> GetTestimonialById(decimal testimonialId)
        {
            return await _testimonalRepositary.GetTestimonialById(testimonialId);
        }

        public async Task<IEnumerable<TestimonialDTO>> GetTestimonialsByExamProviderId(decimal examProviderId)
        {
            return await _testimonalRepositary.GetTestimonialsByExamProviderId(examProviderId);
        }

        public async Task<IEnumerable<TestimonialWithExamProviderDTO>> GetTestimonialsByStateId(decimal stateId)
        {
            return await _testimonalRepositary.GetTestimonialsByStateId(stateId);
        }

        public async Task<Int32> UpdateTestimonialState(decimal testimonialId, decimal stateId)
        {
            return await _testimonalRepositary.UpdateTestimonialState(testimonialId, stateId);
        }
    }
}
