using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Weather
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.Session["User_Id"] == null)
            {
                HttpContext.Current.Session.Clear();
            }
            
            //Response.Redirect("~/Default.aspx");
        }
    }
}