

using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.ICommon;
using Exam_Guardian.core.IRepository;
using Microsoft.Extensions.Logging;
using Exam_Guardian.infra.Utilities;
using Exam_Guardian.infra.Utilities.States;
using Microsoft.EntityFrameworkCore;
namespace Exam_Guardian.infra.Repository
{
    public class TestimonialRepository : ITestimonalRepositary
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;
        private readonly ILogger<TestimonialRepository> _logger;

        public TestimonialRepository(IDbContext dbContext, ModelContext modelContext, ILogger<TestimonialRepository> logger)
        {
            _dbContext = dbContext;
            _modelContext = modelContext;
            _logger = logger;
        }

        public async Task CreateTestimonialAsync(TestimonalModel testimonial)
        {
            if (testimonial == null)
                throw new ArgumentNullException(nameof(testimonial));

            var creatTestimonial = new Testimonial
            {


                Testimonialtext = testimonial.Testimonialtext,
                Testimonalstateid = testimonial.Testimonalstateid,
                ExamProviderId = testimonial.ExamProviderId,

                Userid = testimonial.Userid,

            };

            try
            {
                await _modelContext.Testimonials.AddAsync(creatTestimonial);
                await _modelContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating testimonial");
                throw;
            }
        }

        public async Task DeleteTestimonialAsync(decimal id)
        {
            try
            {
                var testimonial = await _modelContext.Testimonials.FindAsync(id);
                if (testimonial != null)
                {
                    _modelContext.Testimonials.Remove(testimonial);
                    await _modelContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting testimonial");
                throw;
            }
        }

        public async Task<IEnumerable<GetTestimonialViewModel>> GetAllApprovedTestimonialsAsync()
        {

            return await GetTestimonialsByStateAsync(TestimaonalState.Accepted);
        }

        public async Task<IEnumerable<GetTestimonialViewModel>> GetAllRejectedTestimonialsAsync()
        {
            return await GetTestimonialsByStateAsync(TestimaonalState.Rejected);
        }

        public async Task<IEnumerable<GetTestimonialViewModel>> GetAllTestimonialsAsync()
        {
            return await GetTestimonialsByStateAsync(null);
        }

        public async Task<GetTestimonialViewModel> GetTestimonialByIdAsync(int id)
        {
            return (await GetTestimonialsByStateAsync(null, id)).FirstOrDefault() ?? new GetTestimonialViewModel();
        }

        public async Task<IEnumerable<GetTestimonialViewModel>> GetPendingTestimonialsAsync()
        {
            return await GetTestimonialsByStateAsync(TestimaonalState.Pending);
        }

        private async Task<IEnumerable<GetTestimonialViewModel>> GetTestimonialsByStateAsync(int? stateId = null, int? testimonialId = null)
        {
            try
            {
                var query = _modelContext.Testimonials.AsQueryable();

                if (testimonialId.HasValue)
                {
                    query = query.Where(t => t.Testimonialid == testimonialId.Value);
                }
                else if (stateId.HasValue)
                {
                    query = query.Where(t => t.Testimonalstateid == stateId.Value);
                }

                var testimonials = await query
                    .Include(t => t.ExamProvider)
                    .Include(t => t.User)
                    .Select(t => new GetTestimonialViewModel
                    {
                        Testimonialid = t.Testimonialid,
                        Testimonalstateid = t.Testimonalstateid,
                        Userid = t.Userid,
                        Testimonialtext = t.Testimonialtext,
                        Createdat = t.Createdat,
                        Updatedat = t.Updatedat,
                        //ExamProviderId = t.ExamProvider.ExamProviderId,
                        //Image = t.ExamProvider.Image,
                        FirstName = t.User.FirstName,
                        LastName = t.User.LastName,
                    }).ToListAsync();

                return testimonials;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving testimonials");
                throw;
            }
        }
    }
}
