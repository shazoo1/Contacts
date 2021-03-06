﻿using AutoMapper;
using Contacts.Persistence.Entities;
using Contacts.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Web.Mapping
{
    public class ViewModelToEntity : Profile
    {
        public ViewModelToEntity()
        {
            CreateMap<FullPersonInfoModel, PersonEntity>();
        }
    }
}