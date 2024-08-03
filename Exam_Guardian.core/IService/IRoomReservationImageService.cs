using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface IRoomReservationImageService
    {
        Task<int> CreateRoomReservationImage(CreateRoomReservationImageDTO createDto);
        Task<int> DeleteRoomReservationImage(decimal id);
        Task<int> UpdateRoomReservationImage(UpdateRoomReservationImageDTO updateDto);
        Task<RoomReservationImageDTO> GetRoomReservationImageById(decimal id);
        Task<IEnumerable<RoomReservationImageDTO>> GetAllRoomReservationImages();

        Task<IEnumerable<RoomReservationImageDTO>> GetAllRoomReservationImagesBy(decimal reservationId);
    }

}
