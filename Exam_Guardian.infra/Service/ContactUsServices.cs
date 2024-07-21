using Exam_Guardian.core.Data;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class ContactUsServices : IContactUsServices
    {

        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsServices(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public async Task<decimal> CreateContactUs(ContactU contact)
        {
           return await _contactUsRepository.CreateContactUs(contact);
        }

        public async Task<decimal> DeleteContactUs(decimal id)
        {
            return await _contactUsRepository.DeleteContactUs(id);
        }

        public async Task<IEnumerable<ContactU>> GetAllContactUs()
        {
            return await _contactUsRepository.GetAllContactUs();
        }

        public async Task<ContactU> GetContactUsById(decimal id)
        {
            return await _contactUsRepository.GetContactUsById(id);
        }
    }
}
