using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class ReservationInvoiceService : IReservationInvoiceService
    {
        private readonly IReservationInvoiceRepository _repository;

        public ReservationInvoiceService(IReservationInvoiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateReservationInvoice(CreateReservationInvoiceDTO createDto)
        {
            return await _repository.CreateReservationInvoice(createDto);
        }

        public async Task<int> DeleteReservationInvoice(decimal id)
        {
            return await _repository.DeleteReservationInvoice(id);
        }

        public async Task<int> UpdateReservationInvoice(UpdateReservationInvoiceDTO updateDto)
        {
            return await _repository.UpdateReservationInvoice(updateDto);
        }

        public async Task<ReservationInvoiceDTO> GetReservationInvoiceById(decimal id)
        {
            return await _repository.GetReservationInvoiceById(id);
        }

        public async Task<IEnumerable<ReservationInvoiceDTO>> GetAllReservationInvoices()
        {
            return await _repository.GetAllReservationInvoices();
        }

        public async Task<PaginatedResult<ReservationInvoiceDetailsDTO>> GetAllReservationInvoicesDetails(int page, int size)
        {
            return await _repository.GetAllReservationInvoicesDetails().ToPaginatedList(page,size);
        }
    }

}
