using Contacts.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Persistence.Services.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<PersonEntity> GetAll();
        PersonEntity GetById(Guid id);
        int Add(PersonEntity person);
        int Add(IEnumerable<PersonEntity> persons);
        int Edit(PersonEntity person);
        int Remove(Guid id);
    }
}
