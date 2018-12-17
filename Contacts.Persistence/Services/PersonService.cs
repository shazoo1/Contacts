using Contacts.Persistence.Entities;
using Contacts.Persistence.Repositories.Interfaces;
using Contacts.Persistence.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Persistence.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepo _personRepo;

        public PersonService(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }
        public int Add(PersonEntity person)
        {
            person.Id = Guid.NewGuid();
            return _personRepo.Add(person);
        }

        public int Add(IEnumerable<PersonEntity> persons)
        {
            return _personRepo.Add(persons);
        }

        public int Edit(PersonEntity person)
        {
            return _personRepo.Update(person);
        }

        public IEnumerable<PersonEntity> GetAll()
        {
            return _personRepo.GetAll();
        }

        public PersonEntity GetById(Guid id)
        {
            return _personRepo.GetById(id);
        }

        public int Remove(Guid id)
        {
            return _personRepo.Remove(id);
        }
    }
}
