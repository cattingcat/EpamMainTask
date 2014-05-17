using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

using NLog;

using DataAccessors.Accessors;
using DataAccessors.Entity;

using BusinessLogic;


namespace MvcClient.Controllers
{
    public class PersonController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IPersonBll _personBll;

        public PersonController(IPersonBll personBll)
        {
            logger.Trace("Person controller created");
            _personBll = personBll;
        }

        // GET: /Person/
        public ActionResult Index()
        {            
            logger.Trace("Person controller /Index");

            return View(_personBll.GetPersons());
        }
        
        // GET: /Person/Details/5
        public ActionResult Details(int id)
        {
            logger.Trace("Person controller /Details/{0}", id);        
            return View(_personBll.GetPerson(id));
        }
        
        // GET: /Person/Create
        public ActionResult Create()
        {
            logger.Trace("Person controller /Create");

            return View();
        }
        
        // POST: /Person/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            logger.Trace("Person controller /Create/{0} POST", person.Id);

            _personBll.AddPerson(person);
            return RedirectToAction("Index");
        }
        
        // POST: /Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            logger.Trace("Person controller /Delete/{0}", id);

            try
            {
                _personBll.DeletePerson(id);
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
