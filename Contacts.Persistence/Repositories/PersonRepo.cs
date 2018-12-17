using Contacts.Persistence.Entities;
using Contacts.Persistence.Interfaces;
using Contacts.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Persistence.Repositories
{
    public class PersonRepo : IPersonRepo
    {
        protected readonly IContactsDbContext _context;
        protected readonly DbSet<PersonEntity> _dbSet;
        protected static readonly object _locker = new object();
        public PersonRepo(IContactsDbContext context)
        {
            _context = context;
            _dbSet = context.DbContext.Set<PersonEntity>();
        }
        public int Add(PersonEntity item)
        {
            lock (_locker)
            {
                _dbSet.Add(item);
            }
            return _context.DbContext.SaveChanges();
        }

        public int Add(IEnumerable<PersonEntity> items)
        {
            lock (_locker)
            {
                _dbSet.AddRange(items);
            }
            return _context.DbContext.SaveChanges();
        }

        public IEnumerable<PersonEntity> GetAll()
        {
            lock (_locker)
            {
                return _dbSet.ToList();
            }
        }

        public IEnumerable<PersonEntity> GetAllWhere(params Expression<Func<PersonEntity, bool>>[] predicates)
        {
            lock (_locker)
            {
                IEnumerable<PersonEntity> items = GetAll();
                foreach (var predicate in predicates)
                {
                    items = _dbSet.Where(predicate).ToList();
                }
                return items;
            }
        }

        public PersonEntity GetById(Guid id)
        {
            lock (_locker)
            {
                return _dbSet.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public int Remove(PersonEntity item)
        {
            lock (_locker)
            {
                _dbSet.Remove(item);
            }
            return _context.DbContext.SaveChanges();
        }

        public int Remove(Guid id)
        {
            lock (_locker)
            {
                var item = GetById(id);
                if (item != null) _dbSet.Remove(item);
            }
            return _context.DbContext.SaveChanges();
        }

        public int Update(PersonEntity item)
        {
            lock (_locker)
            {
                DbEntityEntry dbEntityEntry = _context.DbContext.Entry(item);
                if (dbEntityEntry.State == EntityState.Detached)
                {
                    _dbSet.Attach(item);
                }
                dbEntityEntry.State = EntityState.Modified;
            }
            return _context.DbContext.SaveChanges();
        }

        public IEnumerable<PersonEntity> GetByIds(IEnumerable<Guid> ids)
        {
            lock (_locker)
            {
                return _dbSet.Where(x => ids.Contains(x.Id)).ToList();
            }
        }
    }
}
