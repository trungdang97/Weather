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
using Newtonsoft.Json;

namespace Weather.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/v1/user")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<User> GetAllUsers()
        {
            using (var db = new cms_VKTTVEntities())
            {
                List<User> lstUser = new List<User>();
                var query = db.aspnet_Membership;
                foreach (var u in query)
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
                        UserId = u.UserId,
                        Phone = u.Phone,
                        IsActive = model.IsActive,
                        RoleId = u.RoleId,
                        Email = u.Email
                        
                    };
                    lstUser.Add(user);
                }
                return lstUser;
            }
        }

        [HttpGet]
        [Route("api/v1/user/filter")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<User> GetFilter(string filterString)
        {
            using (var db = new cms_VKTTVEntities())
            {
                UserFilter filter = JsonConvert.DeserializeObject<UserFilter>(filterString);
                List<User> lstUser = new List<User>();
                var query = db.aspnet_Membership.Where(x => x.FullName.Contains(filter.FilterText) || 
                                                                x.Email.Contains(filter.FilterText) || 
                                                                x.NickName.Contains(filter.FilterText) || 
                                                                x.Phone.Contains(filter.FilterText) || 
                                                                x.ShortName.Contains(filter.FilterText));
                if (filter.RoleId.HasValue)
                {
                    query = query.Where(x => x.RoleId == filter.RoleId);
                }

                foreach (var u in query)
                {
                    var model = db.aspnet_Users.Where(x => x.UserId == u.UserId).First();
                    //var rel = db.aspnet_Roles_Rights_Relationship.Where(x => x.RoleId == u.RoleId).ToList();
                    //var rights = new List<aspnet_Rights>();
                    //foreach (var r in rel)
                    //{
                    //    rights.Add(db.aspnet_Rights.Where(x => x.RightId == r.RightId).First());
                    //}
                    var user = new User()
                    {
                        Username = model.Username,
                        FullName = u.FullName,
                        Rights = null,
                        RoleCode = u.aspnet_Roles.Description,
                        RoleName = u.aspnet_Roles.Name,
                        ShortName = u.ShortName,
                        UserId = u.UserId,
                        IsActive = model.IsActive,
                        RoleId = u.RoleId,
                        Phone = u.Phone,
                        Email = u.Email,
                    };
                    lstUser.Add(user);
                }

                int excludedRow = (filter.PageNumber - 1) * filter.PageSize;
                lstUser = lstUser.Skip(excludedRow).Take(filter.PageSize).ToList();

                return lstUser;
            }
        }

        [HttpGet]
        [Route("api/v1/user/single/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public User GetById(Guid id)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var aspuser = db.aspnet_Membership.Where(x => x.UserId == id).First();

                User user = new User()
                {
                    UserId = aspuser.UserId,
                    FullName = aspuser.FullName,
                    RoleId = aspuser.RoleId,
                    RoleName = aspuser.aspnet_Roles.Name,
                    RoleCode = aspuser.aspnet_Roles.Description,
                    ShortName = aspuser.ShortName,
                    Username = db.aspnet_Users.Where(x => x.UserId == aspuser.UserId).First().Username,
                    Email = aspuser.Email,
                    Phone = aspuser.Phone,
                    IsActive = db.aspnet_Users.Where(x => x.UserId == aspuser.UserId).First().IsActive,
                    Rights = new List<Right>()
                };
                List<aspnet_Roles_Rights_Relationship> rel = db.aspnet_Roles_Rights_Relationship.Where(x => x.RoleId == user.RoleId).ToList();
                foreach(var r in rel)
                {
                    user.Rights.Add(new Right(r.aspnet_Rights));
                }

                return user;
            }
        }

        [HttpPost]
        [Route("api/v1/user/create")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public User CreateUser([FromBody]UserCreateModel data)
        {
            try
            {
                using (var db = new cms_VKTTVEntities())
                {
                    Guid id = Guid.NewGuid();
                    string salt = Salt.CreateSalt(32);
                    string pw = ComputeSha256Hash(data.Password + salt);
                    var user = new aspnet_Membership()
                    {
                        UserId = id,
                        PasswordSalt = salt,
                        Password = pw,
                        FullName = data.FullName,
                        Phone = data.Phone,
                        ShortName = data.ShortName,
                        RoleId = data.RoleId
                    };
                    var user_ref = new aspnet_Users()
                    {
                        Username = data.Username,
                        UserId = id
                    };

                    db.aspnet_Membership.Add(user);
                    db.aspnet_Users.Add(user_ref);

                    db.SaveChanges();

                    return new User()
                    {
                        UserId = user_ref.UserId,
                        Username = user_ref.Username,
                    };
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        [HttpPut]
        [Route("api/v1/user/update/password")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public bool ChangePassword([FromBody]UpdatePasswordModel data)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var model = db.aspnet_Membership.Where(x => x.UserId == data.UserId).First();
                if (model != null)
                {
                    if (model.Password.Equals(ComputeSha256Hash(data.OldPassword + model.PasswordSalt)))
                    {
                        model.Password = ComputeSha256Hash(data.NewPassword + model.PasswordSalt);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }



        [HttpPut]
        [Route("api/v1/user/togglelock/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public bool ToggleLockAccount(Guid id)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var model = db.aspnet_Users.Where(x => x.UserId == id).First();
                if (model != null)
                {
                    model.IsActive = !model.IsActive;
                }
                else
                {
                    return false;
                }
                db.SaveChanges();
                return true;
            }
        }

        [HttpPut]
        [Route("api/v1/user/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public bool Update([FromBody]UserUpdateRequestModel model)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var user = db.aspnet_Membership.Where(x => x.UserId == model.UserId).First();
                user.Email = model.Email;
                user.FullName = model.FullName;
                user.ShortName = model.ShortName;
                user.Phone = model.Phone;

                db.SaveChanges();
            }
            return false;
        }

        [HttpPut]
        [Route("api/v1/user/updaterole")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public bool UpdateRole([FromBody]UserUpdateRequestModel model)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var user = db.aspnet_Membership.Where(x => x.UserId == model.UserId).First();
                user.RoleId = model.RoleId;

                db.SaveChanges();
            }
            return false;
        }

        [HttpPost]
        [Route("api/v1/user/register")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<string> RegisterAccount([FromBody]UserRegistrationRequestModel model)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var UsernameValid = db.aspnet_Users.Where(x => x.Username == model.Username).ToList();
                var PhoneValid = db.aspnet_Membership.Where(x => x.Phone == model.Phone).ToList();
                List<string> error = new List<string>();
                if (UsernameValid.Count > 0)
                {
                    error.Add("Tên tài khoản đã được sử dụng!");
                }
                if (PhoneValid.Count > 0)
                {
                    error.Add("Số điện thoại đã được sử dụng!");
                }
                if(UsernameValid.Count > 0 || PhoneValid.Count > 0)
                {
                    return error;
                }

                aspnet_Users user = new aspnet_Users()
                {
                    UserId = Guid.NewGuid(),
                    Username = model.Username,
                    IsActive = true,
                    SimpleAuth = Guid.NewGuid()
                };

                var salt = Salt.CreateSalt(64);
                var normalRoleId = db.aspnet_Roles.Where(x => x.Description == "USER").First().RoleId;
                aspnet_Membership membership = new aspnet_Membership()
                {
                    UserId = user.UserId,
                    FullName = model.FullName,
                    ShortName = model.ShortName,
                    PasswordSalt = salt,
                    Password = ComputeSha256Hash(model.Password + salt),
                    Phone = model.Phone,
                    RoleId = normalRoleId
                };

                db.aspnet_Users.Add(user);
                db.aspnet_Membership.Add(membership);
                db.SaveChanges();

                error.Add("OK. No errors.");
                return error;
            }
        }
    }

    public class UserRegistrationRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        //public string Email { get; set; }
        public string Phone { get; set; }
        public Guid RoleId { get; set; }
    }
    
    public class UserFilter
    {
        public string FilterText { get; set; }
        public Guid? RoleId { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }

    public class UpdatePasswordModel
    {
        public Guid UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class UserUpdateRequestModel
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
    }

    public class UserCreateModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Phone { get; set; }
        public Guid RoleId { get; set; }
    }

    public class Right
    {
        public Guid RightId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public Right(aspnet_Rights right)
        {
            RightId = right.RightId;
            Name = right.Name;
            Code = right.Description;
        }
    }
    

    public static class Salt
    {
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