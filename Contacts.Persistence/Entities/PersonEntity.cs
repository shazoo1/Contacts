using Contacts.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Persistence.Entities
{
    public class PersonEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Genders Gender { get; set; }
        public string Inn { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
