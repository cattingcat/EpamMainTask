using DataAccessors.Accessors;
using DataAccessors.Entity;
using NLog;
using BusinessLogic;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IPhoneBll _phoneBll;
        private IPersonBll _personBll;

        public PhoneController(IPhoneBll phoneBll, IPersonBll personBll)
        {
            logger.Trace("Phone controller created");

            _phoneBll = phoneBll;
            _personBll = personBll;
        }

        // GET: /Phone/
        public ActionResult Index()
        {
            logger.Trace("Phone controller /Index");

            return View(_phoneBll.GetPhones());
        }
        
        // GET: /Phone/Details/5
        // Redirect to owner-person details
        public ActionResult Details(int id)
        {
            logger.Trace("Phone controller /Details/{0}", id);

            Phone phone = _phoneBll.GetPhones().SingleOrDefault(p => p.Id == id);   
            var dict = new System.Web.Routing.RouteValueDictionary();
            dict.Add("id", phone.PersonId);
            return RedirectToAction("Details", "Person", dict);        
        }
        
        // GET: /Phone/Create
        public ActionResult Create()
        {
            logger.Trace("Phone controller /Create");

            ViewBag.Persons = _personBll.GetPersons();
            return View();
        }
        
        // POST: /Phone/Create
        [HttpPost]
        public ActionResult Create(Phone phone)
        {
            logger.Trace("Phone controller /Create POST {0}", phone.Id);

            _phoneBll.AddPhone(phone);
            return RedirectToAction("Index");
        }
        
        // POST: /Phone/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            logger.Trace("Phone controller /Delete/{0}", id);

            try
            {
                _phoneBll.DeletePhone(id);
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
