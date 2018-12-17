using Contacts.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Persistence.Mappings
{
    public class PersonMap : EntityTypeConfiguration<PersonEntity>
    {
        public PersonMap()
        {
            ToTable("People");
            HasKey(x => x.Id);

            Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            Property(x => x.MiddleName)
                .HasMaxLength(100)
                .IsRequired();
            Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();
            Property(x => x.PhoneNumber)
                .HasMaxLength(17)
                .IsRequired();
            Property(x => x.Email)
                .IsRequired();
            Property(x => x.Gender)
                .IsRequired();
            Property(x => x.Inn)
                .HasMaxLength(15);
        }
    }
}
