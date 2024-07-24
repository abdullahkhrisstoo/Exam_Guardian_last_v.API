

using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.ICommon;
using Exam_Guardian.core.IRepository;
using Microsoft.Extensions.Logging;
using Exam_Guardian.infra.Utilities;
using Exam_Guardian.infra.Utilities.States;
using Microsoft.EntityFrameworkCore;
using OracleInternal.Secure.Network;

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

        public async Task CreateTestimonialAsync(CreateTestimonailDTO testimonial)
        {
            if (testimonial == null)
                throw new ArgumentNullException(nameof(testimonial));

            var creatTestimonial = new Testimonial
            {


                TestimonialText = testimonial.TestimonialText,
                TestimonialStateId = testimonial.TestimonialStateId,
                ExamProviderId = testimonial.ExamProviderId,



            };

            try
            {
                creatTestimonial.CreatedAt = DateTime.Now;
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

     
       

        public async Task<Int32> UpdateTestimonialState(decimal testimonialId, decimal stateId) {

            var testimonial = await _modelContext.Testimonials.Where(e => e.TestimonialId == testimonialId)
                .FirstOrDefaultAsync();
            if (testimonial is not null) {

                testimonial.TestimonialStateId = stateId;
                testimonial.UpdatedAt = DateTime.Now;
                return await _modelContext.SaveChangesAsync();
            }
            return 0;
        
        }
    
        public async Task<IEnumerable<TestimonialDTO>> GetTestimonialsByExamProviderId(decimal examProviderId) {
        
            var testimonials = await _modelContext.Testimonials
                .Include(e=>e.TestimonialState).Where(e=>e.ExamProviderId==examProviderId)
                .Select(t => new TestimonialDTO
                {
                    TestimonialId = t.TestimonialId,
                    TestimonalStateId = t.TestimonialStateId,
                    TestimonialText = t.TestimonialText,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt,
                    ExamProviderId = t.ExamProviderId,
                    TestimonialState = t.TestimonialState.TestimonialStateText
                 
                }).ToListAsync();

            return testimonials;

        }
        public async Task<IEnumerable<TestimonialDTO>> GetAllTestimonials()
        {

            var testimonials = await _modelContext.Testimonials
                .Include(e => e.TestimonialState)
                .Select(t => new TestimonialDTO
                {
                    TestimonialId = t.TestimonialId,
                    TestimonalStateId = t.TestimonialStateId,
                    TestimonialText = t.TestimonialText,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt,
                    ExamProviderId = t.ExamProviderId,
                    TestimonialState = t.TestimonialState.TestimonialStateText

                }).ToListAsync();

            return testimonials;

        }
        public async Task<TestimonialDTO> GetTestimonialById(decimal testimonialId)
        {

            var testimonials = await _modelContext.Testimonials
                .Include(e => e.TestimonialState).Where(e=>e.TestimonialId== testimonialId)
                .Select(t => new TestimonialDTO
                {
                    TestimonialId = t.TestimonialId,
                    TestimonalStateId = t.TestimonialStateId,
                    TestimonialText = t.TestimonialText,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt,
                    ExamProviderId = t.ExamProviderId,
                    TestimonialState = t.TestimonialState.TestimonialStateText

                }).FirstOrDefaultAsync();

            return testimonials;

        }
        public async Task<IEnumerable<TestimonialWithExamProviderDTO>> GetTestimonialsByStateId(decimal stateId)
        {
            try
            {
                var query = _modelContext.Testimonials.AsQueryable();

                var testimonials = await query

                .Select(t => new TestimonialWithExamProviderDTO
                {
                    Testimonialid = t.TestimonialId,
                    Testimonalstateid = t.TestimonialStateId,
                    Testimonialtext = t.TestimonialText,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt,
                    ExamProviderId = t.ExamProviderId,
                    TestimonailState=t.TestimonialState.TestimonialStateText,
                    ExamProviderImage=t.ExamProvider !=null ? t.ExamProvider.Image : "",
                    ExamProviderOwnerName = t.ExamProvider.User != null ? t.ExamProvider.User.FirstName : "",
                    ExamProviderName = t.ExamProvider != null ? t.ExamProvider.User.LastName : ""

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
