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
    public class PlanInvoiceService : IPlanInvoiceService
    {
        private readonly IPlanInvoiceRepository _repository;

        public PlanInvoiceService(IPlanInvoiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreatePlanInvoice(CreatePlanInvoiceDTO createDto)
        {
            return await _repository.CreatePlanInvoice(createDto);
        }

        public async Task<int> DeletePlanInvoice(decimal id)
        {
            return await _repository.DeletePlanInvoice(id);
        }

        public async Task<int> UpdatePlanInvoice(UpdatePlanInvoiceDTO updateDto)
        {
            return await _repository.UpdatePlanInvoice(updateDto);
        }

        public async Task<PlanInvoiceDTO> GetPlanInvoiceById(decimal id)
        {
            return await _repository.GetPlanInvoiceById(id);
        }

        public async Task<IEnumerable<PlanInvoiceDTO>> GetAllPlanInvoices()
        {
            return await _repository.GetAllPlanInvoices();
        }

        public async Task<IEnumerable<PlanInvoiceDetailsDTO>> GetAllPlanInvoicesDetails()
        {
            return await _repository.GetAllPlanInvoicesDetails();
        }
    }

}
