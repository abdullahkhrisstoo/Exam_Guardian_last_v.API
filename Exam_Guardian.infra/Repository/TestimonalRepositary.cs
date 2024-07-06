using Dapper;
using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.ICommon;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.Utilities.PackagesConstants;
using Exam_Guardian.infra.Utilities.PackagesConstants;
using Exam_Guardian.infra.Utilities.States;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Repository
{
    public class TestimonalRepositary : ITestimonalRepositary
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;


        public TestimonalRepositary(IDbContext dbContext, ModelContext modelContext)
        {
            _dbContext = dbContext;
            _modelContext = modelContext;
            
        }
        public async  Task <int>CreateTestimonal(TestimonalModel testimonial)
        {
            DynamicParameters param = new();
            param.Add(name: CreateTestimonals.TestimonalStateId,testimonial.Testimonalstateid , dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: CreateTestimonals.UserId, testimonial.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: CreateTestimonals.TestimonialText, testimonial.Testimonialtext, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: CreateTestimonals.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);


            var res = await _dbContext.Connection.ExecuteAsync(CreateTestimonals.Testimonal_PROCEDURE_CREATE, param, commandType: CommandType.StoredProcedure);
            int cid = param.Get<int>(name: CreateTestimonals.C_id);
            return cid;
        }

        public async Task DeleteTestimonal(decimal id)
        {
            var test = await _modelContext.Testimonials.FindAsync(id);
            if (test != null)
            {
                _modelContext.Testimonials.Remove(test);
                await _modelContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Testimonial>> GetAllApprovedTestimonal()
        {
            return await _modelContext.Testimonials
             .Where(t => t.Testimonalstateid == TestimaonalState.Accepted).ToListAsync(); 
             
        }

        public async Task<IEnumerable<Testimonial>> GetAllRejectedTestimoanl()
        {
            return await _modelContext.Testimonials
             .Where(t => t.Testimonalstateid == TestimaonalState.Rejected).ToListAsync();
        }

        public async Task<IEnumerable<Testimonial>> GetAllTestimonal()
        {
            return await _modelContext.Testimonials.ToListAsync();
        }

        public async Task<Testimonial> GetTestimonialById(int id)
        {
            return await _modelContext.Testimonials.Where(x=>x.Testimonialid==id).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Testimonial>> GetAllTestimonals(int? stateId = null, int? testimonialId = null)
        {
            IQueryable<Testimonial> query = _modelContext.Testimonials;

            if (testimonialId.HasValue)
            {
                query = query.Where(x => x.Testimonialid == testimonialId.Value);

            }
            else if (stateId.HasValue)
            {
                query = query.Where(t => t.Testimonalstateid == stateId.Value);
            }

            return await query.ToListAsync();
        }





        //public async Task<int> CreateTestimonal(Testimonial testimonial)
        //{
        //    DynamicParameters param = new();
        //    param.Add(name: nameof(testimonial.Testimonalstate), testimonial.Testimonalstate, DbType.Int32, ParameterDirection.Input);
        //    param.Add(name: nameof(testimonial.Userid), testimonial.Userid, DbType.Int32, ParameterDirection.Input);
        //    param.Add(name: nameof(testimonial.Testimonialtext), testimonial.Testimonialtext, DbType.String, ParameterDirection.Input);
        //    param.Add(name: "C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

        //    await _dbContext.Connection.ExecuteAsync("Testimonal_PROCEDURE_CREATE", param, commandType: CommandType.StoredProcedure);
        //    int cid = param.Get<int>("C_id");
        //    return cid;
        //}

        //public async Task DeleteTestimonal(decimal id)
        //{
        //    var test = await _modelContext.Testimonials.FindAsync(id);
        //    if (test != null)
        //    {
        //        _modelContext.Testimonials.Remove(test);
        //        await _modelContext.SaveChangesAsync();
        //    }
        //}

        //public async Task<IEnumerable<Testimonial>> GetAllTestimonals(int? stateId = null, int? testimonialId = null)
        //{
        //    IQueryable<Testimonial> query = _modelContext.Testimonials;

        //    if (testimonialId.HasValue)
        //    {
        //        query = query.Where(x => x.Testimonialid == testimonialId.Value);
        //    }
        //    else if (stateId.HasValue)
        //    {
        //        query = query.Where(t => t.Testimonalstateid == stateId.Value);
        //    }

        //    return await query.ToListAsync();
        //}

        //public async Task<Testimonial> GetTestimonialById(int id)
        //{
        //    return await _modelContext.Testimonials.SingleOrDefaultAsync(x => x.Testimonialid == id);
        //}






    }
}
