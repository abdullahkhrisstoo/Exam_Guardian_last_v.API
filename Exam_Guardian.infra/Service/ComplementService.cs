using Exam_Guardian.core.Data;
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
    public class ComplementService : IComplementService
    {
        private readonly IComplementRepository _complementRepository;

        public ComplementService(IComplementRepository complementRepository)
        {
            _complementRepository = complementRepository;
        }

        public async Task<int> CreateComplement(CreateComplementDTO createComplementViewModel)
        {
            return await _complementRepository.CreateComplement(createComplementViewModel);
        }

        public async Task<int> DeleteComplement(int id)
        {
            return await _complementRepository.DeleteComplement(id);
        }

        public async Task<int> UpdateComplement(UpdateComplementDTO updateComplementViewModel)
        {
            return await _complementRepository.UpdateComplement(updateComplementViewModel);
        }

        public async Task<ComplementDTO> GetComplementById(int id)
        {
            return await _complementRepository.GetComplementById(id);
        }

        public async Task<IEnumerable<ComplementDTO>> GetAllComplements()
        {
            return await _complementRepository.GetAllComplements();
        }



        public async Task<IEnumerable<Complement>> GetComplementsByProctorId(int id)
        {
            return await _complementRepository.GetComplementsByProctorId(id);
        }



        public async Task<ComplementDTO> GetComplementByExamReservationId(int examReservationId)
        {
            return await _complementRepository.GetComplementByExamReservationId(examReservationId);
        }
    }

}
