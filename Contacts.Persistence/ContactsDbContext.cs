using Contacts.Persistence.Entities;
using Contacts.Persistence.Interfaces;
using Contacts.Persistence.Mappings;
using Contacts.Persistence.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Persistence
{
    public class ContactsDbContext : DbContext, IContactsDbContext
    {
        DbSet<PersonEntity> People { get; set; }

        public DbContext DbContext { get => this; }

        public ContactsDbContext() : base("PeopleConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContactsDbContext, Configuration>());
        }

        public static ContactsDbContext Create()
        {
            return new ContactsDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new PersonMap());
        }
    }
}
