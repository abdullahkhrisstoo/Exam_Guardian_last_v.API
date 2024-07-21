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
        Task CreateTestimonialAsync(TestimonalModel testimonial);
        Task DeleteTestimonialAsync(decimal id);
        Task<IEnumerable<GetTestimonialViewModel>> GetAllApprovedTestimonialsAsync();
        Task<IEnumerable<GetTestimonialViewModel>> GetAllRejectedTestimonialsAsync();
        Task<IEnumerable<GetTestimonialViewModel>> GetAllTestimonialsAsync();
        Task<GetTestimonialViewModel> GetTestimonialByIdAsync(int id);
        Task<IEnumerable<GetTestimonialViewModel>> GetPendingTestimonialsAsync();
        Task UpdateTestimonial(int id, int testimonalstateid);
    }
}
