using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Repository
{
    public class AboutRepository : IAboutRepository
    {
        private readonly ModelContext _context;

        public AboutRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task CreateAbout(AboutDTO aboutDto)
        {
            if (aboutDto == null)
                throw new ArgumentNullException(nameof(aboutDto));

            var about = new About
            {
                Title = aboutDto.Title,
                Aboutpoints = aboutDto.AboutPoints.Select(item => new Aboutpoint
                {
                    Listitem = item
                }).ToList()
            };

            await _context.Abouts.AddAsync(about);

            await _context.SaveChangesAsync();
        }



        public async Task DeleteAbout(decimal id)
        {
            var about = await _context.Abouts
                .Include(a => a.Aboutpoints)
                .SingleOrDefaultAsync(a => a.AboutId == id);

            if (about == null)
                throw new KeyNotFoundException($"About with Id {id} not found.");

            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();
        }


        public async Task<About> getAboutById(decimal id)
        {
            var about = await _context.Abouts
            .Include(a => a.Aboutpoints) 
            .SingleOrDefaultAsync(a => a.AboutId == id);

            if (about == null)
                throw new KeyNotFoundException($"About with Id {id} not found.");

            return about;
        }

        public async Task<List<About>> GetAllAbout()
        {
            return await _context.Abouts
               .Include(a => a.Aboutpoints).OrderByDescending(a=>a.Aboutpoints.Count()) 
               .ToListAsync();
        }

        public async Task UpdateAbout(decimal id, AboutDTO aboutDto)
        {
            if (aboutDto == null)
                throw new ArgumentNullException(nameof(aboutDto));

            // Find the existing About entity by id
            var existingAbout = await _context.Abouts
                .Include(a => a.Aboutpoints)  // Include related Aboutpoints
                .SingleOrDefaultAsync(a => a.AboutId == id);

            if (existingAbout == null)
                throw new KeyNotFoundException($"About with Id {id} not found.");

            // Update the Title
            existingAbout.Title = aboutDto.Title;

            // Remove existing Aboutpoints
            _context.Aboutpoints.RemoveRange(existingAbout.Aboutpoints);

            // Add new Aboutpoints
            existingAbout.Aboutpoints = aboutDto.AboutPoints.Select(item => new Aboutpoint
            {
                Listitem = item
            }).ToList();

            // Save changes to the database
            await _context.SaveChangesAsync();
        }

    }
}
