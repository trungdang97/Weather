using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weather.Data;
using Weather.Login;
using static Weather.Login.LoginForm;

namespace Weather
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }

        protected void LoginBtn_click(object sender, EventArgs e)
        {
            string username = "";
            string password = "";
            NameValueCollection nvc = Request.Form;
            if (!string.IsNullOrEmpty(nvc["username"]))
            {
                username = nvc["username"];
            }

            if (!string.IsNullOrEmpty(nvc["password"]))
            {
                password = nvc["password"];
            }

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                using (var context = new cms_VKTTVEntities())
                {
                    var query = context.aspnet_Users.Where(x => x.Username == username && x.IsActive);
                    aspnet_Users user_ref = query.Count() == 0 ? null : query.First();
                    if (user_ref != null)
                    {
                        aspnet_Membership user = context.aspnet_Membership.Where(x => x.UserId == user_ref.UserId).First();
                        if (user.Password.Equals(ComputeSha256Hash(password + user.PasswordSalt)))
                        {
                            //HttpContext.Current.Session.Clear();
                            var rel = context.aspnet_Roles_Rights_Relationship.Where(x => x.RoleId == user.RoleId);
                            var rights = new List<aspnet_Rights>();
                            var rightsCodes = new List<string>();
                            foreach (var r in rel)
                            {
                                rights.Add(context.aspnet_Rights.Where(x => x.RightId == r.RightId).First());
                                rightsCodes.Add(context.aspnet_Rights.Where(x => x.RightId == r.RightId).First().Description);
                            }
                            User webUser = ConvertUser(user, username, rights);
                            HttpContext.Current.Session["User_Id"] = webUser.UserId;
                            HttpContext.Current.Session["User_FullName"] = webUser.FullName;
                            HttpContext.Current.Session["User_ShortName"] = webUser.ShortName;
                            HttpContext.Current.Session["User_RoleName"] = webUser.RoleName;
                            HttpContext.Current.Session["User_RoleCode"] = webUser.RoleCode;
                            HttpContext.Current.Session["User_Rights"] = webUser.Rights;
                            HttpContext.Current.Session["User_RightsCode"] = rightsCodes;
                            HttpContext.Current.Session["SimpleAuth"] = webUser.SimpleAuth = Guid.NewGuid();
                            user_ref.SimpleAuth = webUser.SimpleAuth;
                            context.SaveChangesAsync();


                            //Response.Redirect("~/CMS/news.aspx");
                        }
                        else
                        {
                            HttpContext.Current.Session.Abandon();
                            HttpContext.Current.Session["warning"] = "Tài khoản/mật khẩu không đúng";
                        }
                    }
                    else
                    {
                        HttpContext.Current.Session.Abandon();
                        Response.Redirect("~/Login/Index.aspx");
                        HttpContext.Current.Session["warning"] = "Tài khoản/mật khẩu không đúng";
                    }
                }
            }
        }
    }
}