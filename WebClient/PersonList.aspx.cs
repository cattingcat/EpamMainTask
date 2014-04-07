using DataAccessors.Accessors;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class PersonList : System.Web.UI.Page
    {
        private IAccessor<Person> accessor;
        private Stopwatch sw = new Stopwatch();

        protected void Page_Init(object sender, EventArgs e){
            sw.Start();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string key = accessorSelector.SelectedValue;
            accessor = Global.Accessors[key];

            string personId = Request["delete"];
            if (!string.IsNullOrEmpty(personId))
            {
                accessor.DeleteById(int.Parse(personId));
            }            
        }

        protected void InsertClick(object sender, EventArgs e)
        {
            Person p = new Person{
                ID = int.Parse(idInput.Value),
                Name = nameInput.Value.Trim(),
                LastName = lastNameInput.Value.Trim(),
                DayOfBirth = DateTime.Parse(dateInput.Value)             
            };
            accessor.Insert(p);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Person p in accessor.GetAll())
            {
                sb.AppendFormat(@"
                  <tr>
                  <td>{0}</td>
                  <td>{1}</td>
                  <td>{2}</td>
                  <td>{3}</td>
                  <td>" +
                    "<button type=\"submit\" value=\"{0}\" name=\"delete\" class=\"btn btn-xs btn-danger\">Delete</button>" +
                @"</td></tr>",
                p.ID, p.Name, p.LastName, p.DayOfBirth.ToString("dd MMM yyyy"));
            }
            tableBody.InnerHtml = sb.ToString();
            sw.Stop();
            elapsedTime.InnerText = "elapsed time: " + sw.ElapsedMilliseconds + "ms.";
        }
    }
}