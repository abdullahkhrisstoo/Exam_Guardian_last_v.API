using Exam_Guardian.core.Data;
using Exam_Guardian.core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Repository
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly ModelContext _modelContext;

        public ContactUsRepository(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<decimal> CreateContactUs(ContactU contact)
        {
            contact.CreatedAt = DateTime.Now;
            contact.UpdatedAt = DateTime.Now;
            _modelContext.ContactUs.Add(contact);
             await _modelContext.SaveChangesAsync();
            return contact.ContactId;

        }

        public async Task<decimal> DeleteContactUs(decimal id)
        {
            var contact = await _modelContext.ContactUs.FindAsync(id);
            if (contact == null)
            {
                return 0;
            }

            _modelContext.ContactUs.Remove(contact);
                await _modelContext.SaveChangesAsync();
            return contact.ContactId;
        }

        public async Task<IEnumerable<ContactU>> GetAllContactUs()
        {
            return await _modelContext.ContactUs.ToListAsync();
        }

        public async Task<ContactU> GetContactUsById(decimal id)
        {
            return await _modelContext.ContactUs.SingleOrDefaultAsync(contact => contact.ContactId == id);
        }
    }
}
