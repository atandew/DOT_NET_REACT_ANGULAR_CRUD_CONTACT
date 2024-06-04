using ContactCrud.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCrud.Application.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(long id);

        Task<string> AddAsync(Contact contact);

        Task<string> UpdateAsync(int cid, Contact contact);

        Task<string> DeleteAsync(long id);
    }
}
