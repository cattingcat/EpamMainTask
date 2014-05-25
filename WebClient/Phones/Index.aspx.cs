using BusinessLogic;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient.Phones
{
    public partial class Index : System.Web.UI.Page
    {
        private IPhoneBll _phoneBll;

        public Index(){ }
        public Index(IPhoneBll phoneBll)
        {
            _phoneBll = phoneBll;
        }

        public IEnumerable<Phone> Phones { get; set; }


        protected void Page_PreInit(object sender, EventArgs e)
        {
            Phones = _phoneBll.GetPhones();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["delete"] != null)
            {
                DeletePhone();
                Global.Logger.Trace("phone deleted");
            }
        }


        private void DeletePhone()
        {
            if (CaptchaValid())
            {
                int phoneId = int.Parse(Request.Form["delete"]);
                _phoneBll.DeletePhone(phoneId);
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