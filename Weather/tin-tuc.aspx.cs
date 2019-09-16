using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weather.Data;

namespace Weather
{
    public partial class tin_tuc : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Uri uri = Request.Url;

            HttpContext.Current.Session["NewsId"] = "";
            string newsid = HttpUtility.ParseQueryString(uri.Query).Get("tin");
            if (!string.IsNullOrEmpty(newsid))
            {
                HttpContext.Current.Session["NewsId"] = newsid;
            }

            //phân tích url
            if (uri.LocalPath != "/tin-tuc")
            {
                string description = uri.LocalPath.Replace("/tin-tuc/", "");
                HttpContext.Current.Session["NewsCategory"] = "";
                using (var db = new cms_VKTTVEntities())
                {
                    var newsCategory = db.cms_NewsCategory.Where(x => x.Description == description).First();
                    HttpContext.Current.Session["NewsCategory"] = newsCategory.NewsCategoryId;
                }
            }
        }
    }
}