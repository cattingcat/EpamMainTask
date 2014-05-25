using BusinessLogic;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.Patrials;

namespace WebClient.Persons
{
    public partial class Index : System.Web.UI.Page
    {
        private IPersonBll _personBll;

        public Index() { }
        public Index(IPersonBll personBusinessLogic)
        {
            _personBll = personBusinessLogic;
        }

        public IEnumerable<Person> Persons { get; set; }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Persons = _personBll.GetPersons();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["delete"] != null)
            {
                DeletePerson();
                Global.Logger.Trace("deleted person");
            }
        }

        // events here

        protected void Page_PreRender(object sender, EventArgs e)
        {

        }

        private void DeletePerson()
        {
            if (CaptchaValid())
            {
                int personId = int.Parse(Request.Form["delete"]);
                _personBll.DeletePerson(personId);
            }
        }

        private bool CaptchaValid()
        {
            int cpt = (int)Session["captcha"];
            int input;
            if (int.TryParse(captcha.CaptchaInput, out input) && input == cpt)
                return true;
            return false;
        }
    }
}