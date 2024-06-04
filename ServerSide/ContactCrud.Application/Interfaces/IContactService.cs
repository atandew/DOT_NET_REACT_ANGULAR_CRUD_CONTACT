using ContactCrud.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCrud.Application.Interfaces
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContacts();

        Task<Contact> GetContactById(long id);

        Task<string> AddContact(Contact contact);

        Task<string> UpdateContact(int cid, Contact contact);

        Task<string> DeleteContact(long id);

    }
}
