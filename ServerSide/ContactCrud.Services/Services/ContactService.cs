using ContactCrud.Application.Interfaces;
using ContactCrud.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCrud.Services.Services
{
    public class ContactService: IContactService
    {

        private readonly IContactRepository contactRepository;

        public ContactService(IContactRepository contactRepository) {
            this.contactRepository = contactRepository;
        }

        public Task<List<Contact>> GetAllContacts()
        {
           var contacts = contactRepository.GetAllAsync();
           return contacts;
        }

        public Task<Contact> GetContactById(long id) 
        {
            var contactId = contactRepository.GetByIdAsync(id);
            return contactId;

        }

        public Task<string> AddContact(Contact contact)
        {
            if (contact.PhoneNumber?.Length != 10) throw new Exception("Phone number should have 10 digits");
            var Contact = contactRepository.AddAsync(contact);
            return Contact;
        }

        public Task<string> UpdateContact(int cid, Contact contact)
        {
            var Contact = contactRepository.UpdateAsync(cid, contact);
            
            return Contact;
        }

        public Task<string> DeleteContact(long id)
        {
            var Contact = contactRepository.DeleteAsync(id);
            return Contact;
        }
    }
}
