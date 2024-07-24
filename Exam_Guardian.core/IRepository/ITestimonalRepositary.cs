using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IRepository
{
    public interface ITestimonalRepositary
    {
        Task CreateTestimonialAsync(CreateTestimonailDTO testimonial);
        Task DeleteTestimonialAsync(decimal id);
        Task<IEnumerable<TestimonialWithExamProviderDTO>> GetTestimonialsByStateId(decimal stateId);
        Task<IEnumerable<TestimonialDTO>> GetAllTestimonials();
        Task<TestimonialDTO> GetTestimonialById(decimal testimonialId);
        Task<IEnumerable<TestimonialDTO>> GetTestimonialsByExamProviderId(decimal examProviderId);
         Task<Int32> UpdateTestimonialState(decimal testimonialId, decimal stateId);
    }
}
