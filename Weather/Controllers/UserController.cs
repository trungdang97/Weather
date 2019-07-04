using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Http.Cors;
using Weather.Data;
using Weather.Login;
using static Weather.Login.LoginForm;

namespace Weather.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/v1/user")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<User> GetUsers()
        {
            using (var db = new cms_VKTTVEntities())
            {
                List<User> lstUser = new List<User>();
                var query = db.aspnet_Membership;
                foreach(var u in query)
                {
                    var model = db.aspnet_Users.Where(x => x.UserId == u.UserId).First();
                    var rel = db.aspnet_Roles_Rights_Relationship.Where(x => x.RoleId == u.RoleId).ToList();
                    var rights = new List<aspnet_Rights>();
                    foreach (var r in rel)
                    {
                        rights.Add(db.aspnet_Rights.Where(x => x.RightId == r.RightId).First());
                    }
                    var user = new User()
                    {
                        Username = model.Username,
                        FullName = u.FullName,
                        Rights = null,
                        RoleCode = u.aspnet_Roles.Description,
                        RoleName = u.aspnet_Roles.Name,
                        ShortName = u.ShortName,
                        UserId = u.UserId
                    };
                    lstUser.Add(user);
                }
                return lstUser;
            }
        }

        [HttpPost]
        [Route("api/v1/user/create")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public void CreateUser([FromBody]UserCreateModel data)
        {
            using (var db = new cms_VKTTVEntities())
            {
                Guid id = Guid.NewGuid();
                string salt = Salt.CreateSalt(32);
                string pw = ComputeSha256Hash(data.Password+ salt);
                var user = new aspnet_Membership() {
                    UserId = id,
                    PasswordSalt = salt,
                    Password = pw,
                    FullName = data.FullName,
                    ShortName = data.ShortName,
                    RoleId = data.RoleId
                };
                var user_ref = new aspnet_Users() {
                    Username = data.Username,
                    UserId = id
                };

                db.aspnet_Membership.Add(user);
                db.aspnet_Users.Add(user_ref);

                db.SaveChanges();
            }
        }

        [HttpPut]
        [Route("api/v1/user/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public bool ChangePassword([FromBody]UpdatePasswordModel data)
        {
            using(var db = new cms_VKTTVEntities())
            {
                var model = db.aspnet_Membership.Where(x => x.UserId == data.UserId).First();
                if (model != null)
                {
                    if(model.Password.Equals(ComputeSha256Hash(data.OldPassword + model.PasswordSalt))){
                        model.Password = ComputeSha256Hash(data.NewPassword + model.PasswordSalt);
                        db.SaveChanges();
                        return true;
                    }                    
                }
            }
            return false;
        }
    }

    public class UpdatePasswordModel
    {
        public Guid UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class UserCreateModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public Guid RoleId { get; set; }
    }

    public static class Salt {
        public static string CreateSalt(int size)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }
    }
}