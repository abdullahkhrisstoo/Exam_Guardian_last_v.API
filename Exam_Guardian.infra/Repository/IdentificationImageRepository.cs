using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Repository
{
    public class IdentificationImageRepository : IIdentificationImageRepository
    {
        private readonly ModelContext _context;

        public IdentificationImageRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<int> CreateIdentificationImage(CreateIdentificationImageDTO createDto)
        {
            var entity = new IdentificationImage
            {
                PathImageBack = createDto.PathImageBack,
                PathImageFront = createDto.PathImageFront,
                ExamReservationId = createDto.ExamReservationId
            };

            await _context.IdentificationImages.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteIdentificationImage(decimal id)
        {
            var entity = await _context.IdentificationImages.FindAsync(id);
            if (entity == null) return 0;

            _context.IdentificationImages.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateIdentificationImage(UpdateIdentificationImageDTO updateDto)
        {
            var entity = await _context.IdentificationImages.FindAsync(updateDto.IdentificationImageId);
            if (entity == null) return 0;

            entity.PathImageBack = updateDto.PathImageBack;
            entity.PathImageFront = updateDto.PathImageFront;
            entity.ExamReservationId = updateDto.ExamReservationId;

            _context.IdentificationImages.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IdentificationImageDTO> GetIdentificationImageById(decimal id)
        {
            var entity = await _context.IdentificationImages.FindAsync(id);
            if (entity == null) throw new Exception("Identification image not found");

            return new IdentificationImageDTO
            {
                IdentificationImageId = entity.IdentificationImageId,
                PathImageBack = entity.PathImageBack,
                PathImageFront = entity.PathImageFront,
                ExamReservationId = entity.ExamReservationId
            };
        }

        public async Task<IEnumerable<IdentificationImageDTO>> GetAllIdentificationImages()
        {
            return await _context.IdentificationImages.Select(e => new IdentificationImageDTO
            {
                IdentificationImageId = e.IdentificationImageId,
                PathImageBack = e.PathImageBack,
                PathImageFront = e.PathImageFront,
                ExamReservationId = e.ExamReservationId
            }).ToListAsync();
        }
        public async Task<IdentificationImageDTO> GetIdentificationImageBy(decimal reservationId)
        {
            return await _context.IdentificationImages.Select(e => new IdentificationImageDTO
            {
                IdentificationImageId = e.IdentificationImageId,
                PathImageBack = e.PathImageBack,
                PathImageFront = e.PathImageFront,
                ExamReservationId = e.ExamReservationId
            }).Where(e => e.ExamReservationId == reservationId).FirstAsync();
        }

    }

}
