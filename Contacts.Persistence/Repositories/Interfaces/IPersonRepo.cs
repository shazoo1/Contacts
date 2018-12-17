using Contacts.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Persistence.Repositories.Interfaces
{
    public interface IPersonRepo
    {
        int Add(PersonEntity item);
        int Add(IEnumerable<PersonEntity> items);
        IEnumerable<PersonEntity> GetAll();
        IEnumerable<PersonEntity> GetAllWhere(params Expression<Func<PersonEntity, bool>>[] predicates);
        PersonEntity GetById(Guid id);
        int Remove(PersonEntity item);
        int Remove(Guid id);
        int Update(PersonEntity item);
        IEnumerable<PersonEntity> GetByIds(IEnumerable<Guid> ids);
    }
}
