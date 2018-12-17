using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Web.Mapping
{
    public class Configuration
    {
        public static MapperConfiguration Create()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToViewModel());
                cfg.AddProfile(new ViewModelToEntity());
            });
        }

        public static IMapper CreateMapper() => new Mapper(Create());
    }
}