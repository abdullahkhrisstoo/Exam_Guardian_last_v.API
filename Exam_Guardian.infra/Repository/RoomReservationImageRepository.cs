using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IRepository
{
    public class RoomReservationImageRepository : IRoomReservationImageRepository
    {
        private readonly ModelContext _context;

        public RoomReservationImageRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<int> CreateRoomReservationImage(CreateRoomReservationImageDTO createDto)
        {
            var entity = new RoomReservationImage
            {
                Place = createDto.Place,
                ExamReservationId = createDto.ExamReservationId,
                Path = createDto.Path
            };

            await _context.RoomReservationImages.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteRoomReservationImage(decimal id)
        {
            var entity = await _context.RoomReservationImages.FindAsync(id);
            if (entity == null) return 0;

            _context.RoomReservationImages.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateRoomReservationImage(UpdateRoomReservationImageDTO updateDto)
        {
            var entity = await _context.RoomReservationImages.FindAsync(updateDto.RoomReservationImageId);
            if (entity == null) return 0;

            entity.Place = updateDto.Place;
            entity.ExamReservationId = updateDto.ExamReservationId;
            entity.Path = updateDto.Path;

            _context.RoomReservationImages.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<RoomReservationImageDTO> GetRoomReservationImageById(decimal id)
        {
            var entity = await _context.RoomReservationImages.FindAsync(id);
            if (entity == null) throw new Exception("Room reservation image not found");

            return new RoomReservationImageDTO
            {
                RoomReservationImageId = entity.RoomReservationImageId,
                Place = entity.Place,
                ExamReservationId = entity.ExamReservationId,
                Path = entity.Path
            };
        }

        public async Task<IEnumerable<RoomReservationImageDTO>> GetAllRoomReservationImages()
        {
            return await _context.RoomReservationImages.Select(e => new RoomReservationImageDTO
            {
                RoomReservationImageId = e.RoomReservationImageId,
                Place = e.Place,
                ExamReservationId = e.ExamReservationId,
                Path = e.Path
            }).ToListAsync();
        }
        public async Task<IEnumerable<RoomReservationImageDTO>> GetAllRoomReservationImagesBy(decimal reservationId)
        {
            return await _context.RoomReservationImages.Select(e => new RoomReservationImageDTO
            {
                RoomReservationImageId = e.RoomReservationImageId,
                Place = e.Place,
                ExamReservationId = e.ExamReservationId,
                Path = e.Path
            }).Where(e => e.ExamReservationId == reservationId).ToListAsync();
        }
      
    }

}
