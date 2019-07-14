using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weather.Data;

namespace Weather.CMS
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["User_Id"] == null)
            {
                Response.Redirect("~/Login/Index");
            }
            else if (HttpContext.Current.Session["User_RoleCode"].ToString() != "QTHT")
            {
                Response.Redirect("~/Login/Index");
            }

            using (var db = new cms_VKTTVEntities())
            {
                var roles = db.aspnet_Roles;
                foreach (var r in roles)
                {
                    ListRoles.Items.Add(new ListItem()
                    {
                        Text = r.Name,
                        Value = r.RoleId.ToString()
                    });
                    ListRoles2.Items.Add(new ListItem()
                    {
                        Text = r.Name,
                        Value = r.RoleId.ToString()
                    });
                    ListRolesOutter.Items.Add(new ListItem()
                    {
                        Text = r.Name,
                        Value = r.RoleId.ToString()
                    });
                }
                
            }
        }
    }
}