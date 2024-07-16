using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IRepository
{
    public interface IContactUsRepository
    {
        Task<decimal> CreateContactUs(ContactU contact);
        Task<decimal> DeleteContactUs(decimal id);
        Task<ContactU> GetContactUsById(decimal id);
        Task<IEnumerable<ContactU>> GetAllContactUs();
    }
}
