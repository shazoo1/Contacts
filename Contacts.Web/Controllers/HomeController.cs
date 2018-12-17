using AutoMapper;
using Contacts.Persistence.Entities;
using Contacts.Persistence.Services.Interfaces;
using Contacts.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contacts.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPersonService _personService;
        private IMapper _mapper;

        public HomeController(IPersonService personService, IMapper mapper)
        {
            _mapper = mapper;
            _personService = personService;
        }

        public ActionResult Index()
        {
            //Sort by last name by default
            var model = GetModel("lastName", null);
            model.Person = new FullPersonInfoModel();
            return View(model);
        }

        public PartialViewResult AddContact()
        {
            return PartialView(new FullPersonInfoModel());
        }

        [HttpPost]
        public ActionResult AddContact(FullPersonInfoModel model)
        {
            if (ModelState.IsValid)
            {
                _personService.Add(_mapper.Map<PersonEntity>(model));
                return Json(new { success = true });
            }
            return PartialView("AddContact", model);
        }

        public ActionResult GetContacts(string sortOrder, int? page)
        {
            return PartialView("ContactsGrid", GetModel(sortOrder, page));
        }

        private ContactsListViewModel GetModel(string sortOrder, int? page)
        {
            ViewBag.currentSort = sortOrder;

            if (page == null)
            {
                ViewBag.FirstNameSortParm = sortOrder == "firstName" ? "firstNameDesc" : "firstName";
                ViewBag.LastNameSortParm = sortOrder == "lastName" ? "lastNameDesc" : "lastName";
                ViewBag.EmailSortParm = sortOrder == "email" ? "emailDesc" : "email";
            }
            ViewBag.CurrentPage = page;

            var model = new ContactsListViewModel();
            model.SortingOrder = sortOrder;
            var persons = _mapper.Map<IEnumerable<ShortPersonInfoModel>>(_personService.GetAll());

            switch (sortOrder)
            {
                case "firstNameDesc":
                    persons = persons.OrderByDescending(x => x.FirstName);
                    break;
                case "firstName":
                    persons = persons.OrderBy(x => x.FirstName);
                    break;
                case "lastNameDesc":
                    persons = persons.OrderByDescending(x => x.LastName);
                    break;
                case "lastName":
                    persons = persons.OrderBy(x => x.LastName);
                    break;
                case "emailDesc":
                    persons = persons.OrderByDescending(x => x.Email);
                    break;
                case "email":
                    persons = persons.OrderBy(x => x.Email);
                    break;
                default:
                    persons = persons.OrderBy(x => x.LastName);
                    model.SortingOrder = "firstName";
                    break;
            }

            int pageNumber = (page ?? 1);
            model.Persons = persons.ToList().ToPagedList(pageNumber, 10);
            model.PageNumber = pageNumber;
            model.PageCount = model.Persons.PageCount;
            return model;
        }
    }
}