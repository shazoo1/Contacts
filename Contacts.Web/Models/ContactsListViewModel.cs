using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Web.Models
{
    public class ContactsListViewModel
    {
        public IPagedList<ShortPersonInfoModel> Persons { get; set; }
        public FullPersonInfoModel Person { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public string SortingOrder { get; set; }
    }
}