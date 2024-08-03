using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class RoomReservationImageService : IRoomReservationImageService
    {
        private readonly IRoomReservationImageRepository _repository;
        private readonly IFileService _fileService;

        public RoomReservationImageService(IRoomReservationImageRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<int> CreateRoomReservationImage(CreateRoomReservationImageDTO createDto)
        {
            if (createDto.Image is null) {

                throw new Exception("image is not found");
            }
            var imageName=await _fileService.UploadImageAsync(createDto.Image);
            createDto.Path=imageName;
            return await _repository.CreateRoomReservationImage(createDto);
        }

        public async Task<int> DeleteRoomReservationImage(decimal id)
        {
            return await _repository.DeleteRoomReservationImage(id);
        }

        public async Task<int> UpdateRoomReservationImage(UpdateRoomReservationImageDTO updateDto)
        {
            return await _repository.UpdateRoomReservationImage(updateDto);
        }

        public async Task<RoomReservationImageDTO> GetRoomReservationImageById(decimal id)
        {
            return await _repository.GetRoomReservationImageById(id);
        }

        public async Task<IEnumerable<RoomReservationImageDTO>> GetAllRoomReservationImages()
        {
            return await _repository.GetAllRoomReservationImages();
        }

        public async Task<IEnumerable<RoomReservationImageDTO>> GetAllRoomReservationImagesBy(decimal reservationId)
        {
            return await _repository.GetAllRoomReservationImagesBy(reservationId);
        }
    }

}
