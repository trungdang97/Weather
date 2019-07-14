using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weather.Controllers;
using Weather.Data;

namespace Weather.Login
{
    public class User{
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; } 
        public string RoleCode { get; set; }
        public Guid SimpleAuth { get; set; }
        public List<Right> Rights { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["User_Id"] != null)
            {
                Response.Redirect("~/CMS/news");
            }
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

            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                using(var context = new cms_VKTTVEntities())
                {
                    var query = context.aspnet_Users.Where(x => x.Username == username && x.IsActive);
                    aspnet_Users user_ref = query.Count() == 0 ? null : query.First();
                    if(user_ref != null)
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

                            
                            Response.Redirect("~/Default.aspx");
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
                        HttpContext.Current.Session["warning"] = "Tài khoản/mật khẩu không đúng";
                    }
                }
            }
        }

        public static User ConvertUser(aspnet_Membership asp_user, string username, List<aspnet_Rights> rights)
        {
            User user = new User() {
                UserId = asp_user.UserId,
                FullName = asp_user.FullName,
                ShortName = asp_user.ShortName,
                Username = username,
                RoleName = asp_user.aspnet_Roles.Name,
                RoleCode = asp_user.aspnet_Roles.Description,
                Rights = new List<Right>()
            };
            foreach(var r in rights)
            {
                user.Rights.Add(new Right(r));
            }

            return user;
        }

        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}