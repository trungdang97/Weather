using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Weather.Data;

namespace Weather.Controllers
{
    public class APIRegisterRequestModel
    {
        public Guid UserId { get; set; }
        public List<Guid> LstAPI { get; set; }
    }

    public class APIRegisterController : ApiController
    {
        private cms_VKTTVEntities db = new cms_VKTTVEntities();

        // GET: api/API
        [HttpPost]
        [Route("api/v1/APISubscription/register")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Subscribe([FromBody]APIRegisterRequestModel model)
        {
            var success = "Đăng ký sử dụng dịch vụ thành công!";
            var fail = "Đã có lỗi xảy ra khi đăng ký sử dụng dịch vụ. Xin hãy thử lại trong giây lát.";
            try
            {
                // implement CORE LOGIC for PHONE SUBCRIBE PAYMENT
                var accept = true;
                var user = db.aspnet_Membership.Where(x => x.UserId == model.UserId).First();
                if (user == null)
                {
                    throw new Exception();
                }
                /*
                 * LOGIC HERE
                 */

                if (accept)
                {
                    DateTime timestamp = DateTime.Now;
                    int totalPrice = 0;
                    List<cms_API_Membership_Relationship> rel = new List<cms_API_Membership_Relationship>();
                    Random generator = new Random();
                    foreach (var s in model.LstAPI)
                    {
                        var API = db.cms_API.Where(x => x.APIId == s && x.IsActive).First();
                        totalPrice += API.Price;
                        var exist = db.cms_API_Membership_Relationship.Where(x => x.UserId == model.UserId && x.APIId == s);
                        if (exist.Count() > 0)
                        {
                            var item = exist.First();
                            item.AccessToken = Guid.NewGuid();
                            item.FromDate = timestamp;
                            item.ToDate = timestamp.AddMonths(API.Duration);
                            item.AccessCode = generator.Next(0, 999999).ToString("D6");
                            item.IsActive = true;
                        }
                        else
                        {
                            rel.Add(new cms_API_Membership_Relationship()
                            {
                                Id = Guid.NewGuid(),
                                APIId = API.APIId,
                                UserId = model.UserId,
                                AccessToken = Guid.NewGuid(),
                                FromDate = timestamp,
                                ToDate = timestamp.AddMonths(API.Duration),
                                AccessCode = generator.Next(0, 999999).ToString("D6"),
                                IsActive = true
                            });
                        }
                    }
                    cms_UserTransaction transaction = new cms_UserTransaction()
                    {
                        BillId = Guid.NewGuid(),
                        UserId = model.UserId,
                        TotalPrice = totalPrice,
                        CreatedOnDate = timestamp,
                        Paid = true, // 2 cái cuối này cần phải xem phần core logic với viễn thông thanh toán như thế nào
                        PaidOnDate = timestamp
                    };
                    List<cms_UserTransaction_API> transactionDetail = new List<cms_UserTransaction_API>();
                    for (int i = 0; i < model.LstAPI.Count; i++)
                    {
                        transactionDetail.Add(new cms_UserTransaction_API()
                        {
                            Id = Guid.NewGuid(),
                            BillId = transaction.BillId,
                            APIId = model.LstAPI[i],
                            FromDate = rel[i].FromDate,
                            ToDate = rel[i].ToDate
                        });
                    }

                    db.cms_API_Membership_Relationship.AddRange(rel);
                    db.cms_UserTransaction.Add(transaction);
                    db.cms_UserTransaction_API.AddRange(transactionDetail);
                    db.SaveChanges();

                    return success;
                }
                else return fail;
            }
            catch (Exception ex)
            {
                return fail;
            }
        }

        [HttpPost]
        [Route("api/v1/APISubscription/unsubscribe")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Unsubscribe([FromBody]APIRegisterRequestModel model)
        {
            var success = "Hủy dịch vụ thành công!";
            var fail = "Đã có lỗi xảy ra khi hủy dịch vụ. Xin hãy thử lại trong giây lát.";
            try
            {
                // implement CORE LOGIC for PHONE PAYMENT - UNSUBSCRIBE / return policies within few days/hours
                var accept = true;
                var user = db.aspnet_Membership.Where(x => x.UserId == model.UserId).First();
                if (user == null)
                {
                    throw new Exception();
                }
                /*
                 * LOGIC HERE
                 */

                if (accept)
                {
                    List<cms_API_Membership_Relationship> rel = new List<cms_API_Membership_Relationship>();
                    foreach (var s in model.LstAPI)
                    {
                        var RegisteredAPI = db.cms_API_Membership_Relationship.Where(x => x.APIId == s && x.UserId == user.UserId).First();
                        rel.Add(RegisteredAPI);
                    }
                    db.cms_API_Membership_Relationship.RemoveRange(rel);
                    db.SaveChanges();

                    return success;
                }
                else return fail;
            }
            catch (Exception ex)
            {
                return fail;
            }
        }
    }
}