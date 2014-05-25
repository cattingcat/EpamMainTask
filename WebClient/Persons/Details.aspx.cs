using BusinessLogic;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient.Persons
{
    public partial class Details : System.Web.UI.Page
    {
        private IPersonBll _personBll;

        public Details() { }
        public Details(IPersonBll personBusinessLogic)
        {
            _personBll = personBusinessLogic;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsIdDetails())
            {
                Global.Logger.Trace("Person/details with id");
                int id = int.Parse(Request["id"]);
                idField.Enabled = false;
                Person p = _personBll.GetPerson(id);
                FillFields(p);
            }
        }

        protected void Submit_ServerClick(object sender, EventArgs e)
        {
            if (CaptchaValid())
            {
                Person p = ReadFields();
                if (IsIdDetails())
                {
                    _personBll.UpdatePerson(p);
                    Global.Logger.Trace("update person");
                }
                else
                {
                    _personBll.AddPerson(p);
                    Global.Logger.Trace("add person");
                }
                Response.Redirect("~/Persons/Index.aspx");
            }
        }

        private void FillFields(Person p)
        {
            idField.Text = p.Id.ToString();
            nameField.Text = p.Name;
            lastNameField.Text = p.LastName;
            birthdayField.Text = p.DayOfBirth.ToString("d MMM yyyy");
        }

        private Person ReadFields()
        {
            DateTime dt = DateTime.Now;
            DateTime.TryParse(birthdayField.Text, out dt);
            Person p = new Person
            {
                Id = int.Parse(idField.Text),
                Name = nameField.Text,
                LastName = lastNameField.Text,
                DayOfBirth = dt
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