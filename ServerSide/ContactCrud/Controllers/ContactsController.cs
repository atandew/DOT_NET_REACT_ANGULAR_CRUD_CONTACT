using ContactCrud.Api.Models;
using ContactCrud.Application.Interfaces;
using ContactCrud.core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace ContactCrud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService contactService;
       

        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet]
        public async Task<ApiResponse<List<Contact>>> GetAllContacts()
        {
            var apiResponse = new ApiResponse<List<Contact>>();

            try
            {
                 var contacts = await contactService.GetAllContacts();
                 apiResponse.Success = true;
                 apiResponse.Result = contacts.ToList();
                

            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }

            return apiResponse;

        }


        [HttpGet("{id}")]
        public async Task<ApiResponse<Contact>> GetContactById(long id)
        {
            var apiResponse = new ApiResponse<Contact>();

            try
            {
                var contactsId = await contactService.GetContactById(id);
                apiResponse.Success = true;
                apiResponse.Result = contactsId;


            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }

            return apiResponse;

        }


        [HttpPost]
        public async Task<ApiResponse<string>> AddContact(Contact contact)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                var contacts = await contactService.AddContact(contact);
                apiResponse.Success = true;
                apiResponse.Result = contacts;

            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }

            return apiResponse;
        }

        [HttpPut("{id}")]
        public async Task<ApiResponse<string>> UpdateContact(int id, Contact contact)
        {
            var apiResponse = new ApiResponse<string>();
            try
            {
                var contacts = await contactService.UpdateContact(id, contact);
                apiResponse.Success = true;
                apiResponse.Result = contacts;

            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }

            return apiResponse;

        }

        [HttpDelete]
         public async Task<ApiResponse<string>> DeleteContact(long id)
         {
            var apiResponse = new ApiResponse<string>();
            try
            {
                var contacts = await contactService.DeleteContact(id);
                apiResponse.Success = true;
                apiResponse.Result = contacts;

            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }

            return apiResponse;
         }



    }
}
