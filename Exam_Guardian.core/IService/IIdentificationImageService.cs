using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface IIdentificationImageService
    {
        Task<int> CreateIdentificationImage(CreateIdentificationImageDTO createDto);
        Task<int> DeleteIdentificationImage(decimal id);
        Task<int> UpdateIdentificationImage(UpdateIdentificationImageDTO updateDto);
        Task<IdentificationImageDTO> GetIdentificationImageById(decimal id);
        Task<IEnumerable<IdentificationImageDTO>> GetAllIdentificationImages();
        Task<IdentificationImageDTO> GetIdentificationImageBy(decimal reservationId);
    }

}
