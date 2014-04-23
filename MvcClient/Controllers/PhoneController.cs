using DataAccessors.Accessors;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class PhoneController : Controller
    {        
        private IAccessor<Person> _personAccessor;
        private IAccessor<Phone> _phoneAccessor;

        public PhoneController(IAccessor<Phone> phoneAccessor, IAccessor<Person> personAccessor)
        {
            _personAccessor = personAccessor;
            _phoneAccessor = phoneAccessor;
        }

        // GET: /Phone/
        public ActionResult Index()
        {
            return View(_phoneAccessor.GetAll());
        }
        
        // GET: /Phone/Details/5
        // Redirect to owner-person details
        public ActionResult Details(int id)
        {
            Phone phone = _phoneAccessor.GetAll().SingleOrDefault(p => p.Id == id);   
            var dict = new System.Web.Routing.RouteValueDictionary();
            dict.Add("id", phone.PersonId);
            return RedirectToAction("Details", "Person", dict);        
        }
        
        // GET: /Phone/Create
        public ActionResult Create()
        {
            ViewBag.Persons = _personAccessor.GetAll();
            return View();
        }
        
        // POST: /Phone/Create
        [HttpPost]
        public ActionResult Create(Phone phone)
        {
            _phoneAccessor.Insert(phone);
            return RedirectToAction("Index");
        }
        
        // POST: /Phone/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _phoneAccessor.DeleteById(id);
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
