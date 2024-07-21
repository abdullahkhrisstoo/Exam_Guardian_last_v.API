using Exam_Guardian.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface IContactUsServices
    {
        Task<decimal> CreateContactUs(ContactU contact);
        Task<decimal> DeleteContactUs(decimal id);
        Task<ContactU> GetContactUsById(decimal id);
        Task<IEnumerable<ContactU>> GetAllContactUs();
    }
}
