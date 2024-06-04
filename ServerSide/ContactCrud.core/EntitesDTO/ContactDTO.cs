using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCrud.Core.EntitesDTO
{
    public class ContactDTO
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
