using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Weather.Data;

namespace Weather.Controllers
{
    public class APIFilter
    {
        public string FilterText { get; set; }
        public Guid? APITypeId { get; set; }
        //public int PriceBottom { get; set; }
        //public int PriceTop { get; set; }
        //public int Duration { get; set; }
    }
    public class APIUpdateRequestModel
    {
        public Guid APIId { get; set; }
        public string Name { get; set; }
        public string APICode { get; set; }
        public int Duration { get; set; }
        public Guid APITypeId { get; set; }
        public string Body { get; set; }
        public string Documentation { get; set; }
        public string DocumentationLink { get; set; }
        public int Price { get; set; }
        public string DurationText { get; set; }
    }
    public class APICreateRequestModel
    {
        public string Name { get; set; }
        public string APICode { get; set; }
        public int Duration { get; set; }
        public Guid APITypeId { get; set; }
        public string Body { get; set; }
        public string Documentation { get; set; }
        public string DocumentationLink { get; set; }
        public int Price { get; set; }
        public string DurationText { get; set; }
    }
    public class APIResponseModel
    {
        public Guid APIId { get; set; }
        public string Name { get; set; }
        public string APICode { get; set; }
        public int Price { get; set; }
        public string DurationText { get; set; }
        public int Duration { get; set; }
        public Guid APITypeId { get; set; }
        public string Body { get; set; }
        public string Documentation { get; set; }
        public string DocumentationLink { get; set; }
        public bool IsActive { get; set; }
        public string APITypeName { get; set; }
    }
    public class APIUserResponseModel
    {
        public Guid APIId { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class UserTransactionResponseModel
    {
        public Guid BillId { get; set; }
        //public Guid UserId { get; set; }
        public int TotalPrice { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public List<UserTransactionResponseDetailModel> LstAPI { get; set; }
    }
    public class UserTransactionResponseDetailModel
    {
        public string APIName { get; set; }
        public int Price { get; set; }
    }

    public class APIController : ApiController
    {
        private cms_VKTTVEntities db = new cms_VKTTVEntities();

        // GET: api/API
        [HttpGet]
        [Route("api/v1/API/filter")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<APIResponseModel> GetFilter(string filterString)
        {
            List<APIResponseModel> lstAPI = new List<APIResponseModel>();
            APIFilter filter = JsonConvert.DeserializeObject<APIFilter>(filterString);
            var models = db.cms_API.Where(x => x.Name.Contains(filter.FilterText) || x.DurationText.Contains(filter.FilterText));
            if (filter.APITypeId.HasValue)
            {
                models = models.Where(x => x.APITypeId == filter.APITypeId && x.IsActive);
            }

            lstAPI = models.OrderBy(x => x.cms_APIType.Name).ThenBy(x => x.Name).Select(Convert).ToList();
            return lstAPI;
        }

        // GET: api/API
        [HttpGet]
        [Route("api/v1/API/list")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<APIUserResponseModel> GetFilter(Guid userid)
        {
            bool needToSave = false;
            List<APIUserResponseModel> lstAPI = new List<APIUserResponseModel>();
            var models = db.cms_API_Membership_Relationship.Where(x => x.UserId == userid).Include(x => x.cms_API);
            foreach (var m in models)
            {
                var api = db.cms_API.Where(x => x.APIId == m.APIId).First();
                APIUserResponseModel item = new APIUserResponseModel()
                {
                    APIId = api.APIId,
                    Name = api.Name,
                    FromDate = m.FromDate,
                    ToDate = m.ToDate,
                    IsActive = DateTime.Now < m.ToDate ? true : false
                };
                lstAPI.Add(item);
                if (!lstAPI.Last().IsActive)
                {
                    var rel = db.cms_API_Membership_Relationship.Where(x => x.UserId == userid && x.APIId == item.APIId).First();
                    rel.IsActive = false;
                    needToSave = true;
                }
            }
            if (needToSave)
            {
                db.SaveChanges();
            }

            return lstAPI;
        }

        // GET: api/API/5
        [HttpGet]
        [Route("api/v1/API/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public APIResponseModel GetById(Guid id)
        {
            var model = db.cms_API.Where(x => x.APIId == id).First();
            return Convert(model);
        }

        // PUT: api/API/5
        [HttpPut]
        [Route("api/v1/API/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public APIResponseModel Update([FromBody]APIUpdateRequestModel model)
        {
            var api = db.cms_API.Where(x => x.APIId == model.APIId).First();
            api.APITypeId = model.APITypeId;
            api.Body = model.Body;
            api.Documentation = model.Documentation;
            api.DocumentationLink = model.DocumentationLink;
            api.Duration = model.Duration;
            api.DurationText = model.Duration + " tháng";
            api.Name = model.Name;
            api.Price = model.Price;

            db.SaveChanges();

            return Convert(api);
        }

        // POST: api/API
        [HttpPost]
        [Route("api/v1/API/create")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public APIResponseModel Create([FromBody]APICreateRequestModel model)
        {
            cms_API api = new cms_API()
            {
                APIId = Guid.NewGuid(),
                APICode = model.APICode,
                IsActive = true,
                APITypeId = model.APITypeId,
                Body = model.Body,
                Documentation = model.Documentation,
                DocumentationLink = model.DocumentationLink,
                Duration = model.Duration,
                DurationText = model.Duration + " tháng",
                Name = model.Name,
                Price = model.Price
            };
            db.cms_API.Add(api);
            db.SaveChanges();

            return Convert(api);
        }

        // DELETE: api/API/5
        [HttpDelete]
        [Route("api/v1/API/delete/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public APIResponseModel Delete(Guid id)
        {
            var api = db.cms_API.Where(x => x.APIId == id).First();
            db.cms_API.Remove(api);
            db.SaveChanges();

            return Convert(api);
        }

        [HttpPut]
        [Route("api/v1/API/togglelock/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public APIResponseModel ToggleLockAPI(Guid id)
        {
            var api = db.cms_API.Where(x => x.APIId == id).First();
            api.IsActive = !api.IsActive;
            var rel = db.cms_API_Membership_Relationship.Where(x => x.APIId == id);
            foreach (var r in rel)
            {
                r.Disabled = !api.IsActive; // disable các API bị khóa
            }
            db.SaveChanges();

            return Convert(api);
        }

        [HttpGet]
        [Route("api/v1/API/transaction")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<UserTransactionResponseModel> GetTransaction(Guid userid)
        {
            var trans = db.cms_UserTransaction.Where(x => x.UserId == userid).OrderByDescending(x => x.CreatedOnDate).Take(10);
            List<UserTransactionResponseModel> LstTrans = new List<UserTransactionResponseModel>();
            foreach(var t in trans)
            {
                LstTrans.Add(new UserTransactionResponseModel()
                {
                    BillId = t.BillId,
                    CreatedOnDate = t.CreatedOnDate,
                    TotalPrice = t.TotalPrice,
                    LstAPI = new List<UserTransactionResponseDetailModel>()
                });
                var detail = db.cms_UserTransaction_API.Where(x => x.BillId == t.BillId);
                foreach(var d in detail)
                {
                    var api = db.cms_API.Where(x => x.APIId == d.APIId).First();
                    LstTrans.Last().LstAPI.Add(new UserTransactionResponseDetailModel()
                    {
                        APIName = api.Name,
                        Price = d.Price
                    });
                }
            }

            return LstTrans;
        }

        private APIResponseModel Convert(cms_API model)
        {
            return new APIResponseModel()
            {
                APIId = model.APIId,
                APITypeId = model.APITypeId,
                Body = model.Body,
                Documentation = model.Documentation,
                DocumentationLink = model.DocumentationLink,
                Duration = model.Duration,
                DurationText = model.DurationText,
                Name = model.Name,
                Price = model.Price,
                APICode = model.APICode,
                IsActive = model.IsActive,
                APITypeName = model.cms_APIType.Name
            };
        }
    }
}