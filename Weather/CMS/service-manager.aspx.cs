using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weather.Data;

namespace Weather.CMS
{
    public partial class service_manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["User_Id"] == null)
            {
                Response.Redirect("~/Login/Index");
                return;
            }
            if (!((List<string>)Session["User_RightsCode"]).Contains("APICONSUMER"))
            {
                Response.Redirect("~/default.aspx");
                return;
            }
            using (var db = new cms_VKTTVEntities())
            {
                var apiTypes = db.cms_APIType.OrderBy(x => x.Name);
                foreach (var t in apiTypes)
                {
                    ListAPIType.Items.Add(new ListItem()
                    {
                        Text = t.Name,
                        Value = t.APITypeId.ToString()
                    });
                    //ListAPITypeOutter.Items.Add(new ListItem()
                    //{
                    //    Text = t.Name,
                    //    Value = t.APITypeId.ToString()
                    //});
                }
            }
        }
    }
}