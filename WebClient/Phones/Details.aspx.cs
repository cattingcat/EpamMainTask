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
    public partial class Details : System.Web.UI.Page
    {
        private IPhoneBll _phoneBll;

        public Details(){ }
        public Details(IPhoneBll phoneBll)
        {
            _phoneBll = phoneBll;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsIdDetails())
            {
                Global.Logger.Trace("phone/details");
                int id = int.Parse(Request["id"]);
                idField.Enabled = false;
                Phone p = _phoneBll.GetPhone(id);
                FillFields(p);
            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            if (CaptchaValid())
            {
                Phone p = ReadFields();
                if (IsIdDetails())
                {
                    _phoneBll.UpdatePhone(p);
                    Global.Logger.Trace("updated phone");
                }
                else
                {
                    _phoneBll.AddPhone(p);
                    Global.Logger.Trace("phone added");
                }
                Response.Redirect("~/Phones/Index.aspx");
            }
        }


        private void FillFields(Phone p)
        {
            idField.Text = p.Id.ToString();
            numberField.Text = p.Number;
            ownerField.Text = p.PersonId.ToString();
        }

        private Phone ReadFields()
        {
            Phone p = new Phone
            {
                Id = int.Parse(idField.Text),
                Number = numberField.Text,
                PersonId = int.Parse(ownerField.Text)
            };
            return p;
        }

        private bool IsIdDetails()
        {
            string id = Request["id"];
            return !string.IsNullOrEmpty(id);
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