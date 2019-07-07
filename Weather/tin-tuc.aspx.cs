using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Weather
{
    public partial class tin_tuc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Uri uri = Request.Url;

            string newsid = HttpUtility.ParseQueryString(uri.Query).Get("tin");
            HttpContext.Current.Session["newsid"] = newsid;

        }
    }
}