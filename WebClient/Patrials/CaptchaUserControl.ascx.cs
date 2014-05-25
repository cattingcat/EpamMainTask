using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient.Patrials
{
    public partial class CaptchaUserControl : System.Web.UI.UserControl
    {
        public string CaptchaInput
        {
            get
            {
                return captchaField.Value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}