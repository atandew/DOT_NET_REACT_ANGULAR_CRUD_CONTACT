using CleanArch.Sql.Queries;
using ContactCrud.Application.Interfaces;
using ContactCrud.core.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCrud.Infrastructure.Repository
{
    public class ContactRepository: IContactRepository
    {
        private readonly IConfiguration configuration;

        public ContactRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Contact>(ContactQueries.AllContact);
                return result.ToList();
            }
        }

        public async Task<Contact> GetByIdAsync(long id)
        {
            using(IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {

                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Contact>(ContactQueries.ContactById, new { ContactId = id });
                return result;
            }


        }

        public async Task<string> AddAsync(Contact contact)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(ContactQueries.AddContact, contact);
                return result.ToString();
            }

        }

        public async Task<string> UpdateAsync(int cid, Contact contact)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(ContactQueries.GetUpdateContactQuery(cid), contact);
                return result.ToString();
            }

        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(ContactQueries.DeleteContact, new { ContactId = id } );
                return result.ToString();
            }

        }
    }
}
