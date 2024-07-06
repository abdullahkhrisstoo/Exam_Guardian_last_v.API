using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface ITestimonalService
    {
        Task<int> CreateTestimonal(TestimonalModel testimonial);
        Task DeleteTestimonal(decimal id);
        Task<Testimonial> GetTestimonialById(int id);
        Task<IEnumerable<Testimonial>> GetAllTestimonal();
        Task<IEnumerable<Testimonial>> GetAllApprovedTestimonal();
        Task<IEnumerable<Testimonial>> GetAllRejectedTestimoanl();
        Task<IEnumerable<Testimonial>> GetAllTestimonals(int? stateId = null, int? testimonialId = null);
    }
}
