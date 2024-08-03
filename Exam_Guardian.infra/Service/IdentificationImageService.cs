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
    public class IdentificationImageService : IIdentificationImageService
    {
        private readonly IIdentificationImageRepository _repository;
        private readonly IFileService _fileService;
        public IdentificationImageService(IIdentificationImageRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
    
        }

 

        public async Task<int> CreateIdentificationImage(CreateIdentificationImageDTO createDto)
        {
            if (createDto.ImageBack is null || createDto.ImageFront is null) {

                throw new Exception("image back or front is not found");
            }
            var ImageBackName= await _fileService.UploadImageAsync(createDto.ImageBack);
            var ImageFrontName= await _fileService.UploadImageAsync(createDto.ImageFront);
            createDto.PathImageBack = ImageBackName;
            createDto.PathImageFront = ImageFrontName;
            return await _repository.CreateIdentificationImage(createDto);
        }

        public async Task<int> DeleteIdentificationImage(decimal id)
        {
            return await _repository.DeleteIdentificationImage(id);
        }

        public async Task<int> UpdateIdentificationImage(UpdateIdentificationImageDTO updateDto)
        {
            return await _repository.UpdateIdentificationImage(updateDto);
        }

        public async Task<IdentificationImageDTO> GetIdentificationImageById(decimal id)
        {
            return await _repository.GetIdentificationImageById(id);
        }

        public async Task<IEnumerable<IdentificationImageDTO>> GetAllIdentificationImages()
        {
            return await _repository.GetAllIdentificationImages();
        }

        public async  Task<IdentificationImageDTO> GetIdentificationImageBy(decimal reservationId)
        {
            return await _repository.GetIdentificationImageBy(reservationId);
        }
    }

}
