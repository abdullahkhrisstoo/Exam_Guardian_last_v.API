using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface IPlanInvoiceService
    {
        Task<int> CreatePlanInvoice(CreatePlanInvoiceDTO createDto);
        Task<int> DeletePlanInvoice(decimal id);
        Task<int> UpdatePlanInvoice(UpdatePlanInvoiceDTO updateDto);
        Task<PlanInvoiceDTO> GetPlanInvoiceById(decimal id);
        Task<IEnumerable<PlanInvoiceDTO>> GetAllPlanInvoices();

        Task<IEnumerable<PlanInvoiceDetailsDTO>> GetAllPlanInvoicesDetails();
    }

}
