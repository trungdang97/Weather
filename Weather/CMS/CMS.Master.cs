using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weather.Data;
using Weather.Login;
using static Weather.Login.LoginForm;

namespace Weather.CMS
{
    public partial class CMS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["User_Id"] == null)
            {
                Response.Redirect("~/Login/Index");
            }
            else
            {
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
                    }

                }
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }

        [WebMethod]
        protected void ChangePassword(object sender, EventArgs e)
        {
            string oldpassword = "";
            string newpassword = "";
            Guid UserId;
            NameValueCollection nvc = Request.Form;

            if (!string.IsNullOrEmpty(nvc["oldpassword"]))
            {
                oldpassword = nvc["oldpassword"];
            }

            if (!string.IsNullOrEmpty(nvc["newpassword"]))
            {
                newpassword = nvc["newpassword"];
            }
            UserId = Guid.Parse(HttpContext.Current.Session["User_Id"].ToString());

            using (var context = new cms_VKTTVEntities())
            {
                aspnet_Users user_ref = context.aspnet_Users.Where(x => x.UserId == UserId).First();
                if (user_ref != null)
                {
                    aspnet_Membership user = context.aspnet_Membership.Where(x => x.UserId == user_ref.UserId).First();
                    if (user.Password.Equals(ComputeSha256Hash(oldpassword + user.PasswordSalt)))
                    {
                        user.Password = ComputeSha256Hash(newpassword + user.PasswordSalt).ToString();
                        context.SaveChanges();
                        Logout_Click(this, null);
                    }                    
                }
                else
                {
                    HttpContext.Current.Session.Abandon();
                }
            }            
        }       
    }
}