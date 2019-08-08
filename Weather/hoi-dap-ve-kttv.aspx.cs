using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Weather
{
    public partial class hoi_dap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Uri uri = Request.Url;

            HttpContext.Current.Session["PostId"] = "";
            string PostId = HttpUtility.ParseQueryString(uri.Query).Get("cauhoi");
            if (!string.IsNullOrEmpty(PostId))
            {
                HttpContext.Current.Session["PostId"] = PostId;
            }
        }
    }
}