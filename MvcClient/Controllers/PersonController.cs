using DataAccessors.Accessors;
using DataAccessors.Entity;
using MvcClient.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class PersonController : Controller
    {
        private IAccessor<Person> _personAccessor;
        private IAccessor<Phone> _phoneAccessor;

        public PersonController(IAccessor<Person> personAccessor, IAccessor<Phone> phoneAccessor)
        {
            _personAccessor = personAccessor;
            _phoneAccessor = phoneAccessor;
        }

        // GET: /Person/
        public ActionResult Index()
        {
            return View(_personAccessor.GetAll());
        }
        
        // GET: /Person/Details/5
        public ActionResult Details(int id)
        {
            Person person = _personAccessor.GetAll().SingleOrDefault(p => p.Id == id);
            var phones = from p in _phoneAccessor.GetAll() where p.PersonId == id select p;           
            return View(new PersonWithPhonesViewModel {Owner = person, Phones = phones });
        }
        
        // GET: /Person/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: /Person/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            _personAccessor.Insert(person);
            return RedirectToAction("Index");
        }
        
        // POST: /Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _personAccessor.DeleteById(id);
                return RedirectToAction("Index");
            }
            catch (SqlException e)
            {
                Session.Add("Exception", e);
                return RedirectToAction("Index", "Exception");                
            }            
        }     
    }
}
