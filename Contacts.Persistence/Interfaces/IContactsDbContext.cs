using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Persistence.Interfaces
{
    public interface IContactsDbContext : IDisposable
    {
        DbContext DbContext { get; }
    }
}
