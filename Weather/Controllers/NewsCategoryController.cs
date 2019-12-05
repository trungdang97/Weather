using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Weather.Data;

namespace Weather.Controllers
{
    public class NewsCategory
    {
        public Guid NewsCategoryId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int? Order { get; set; }
        public int Quantity { get; set; } = 0;

        public NewsCategory(cms_NewsCategory model)
        {
            NewsCategoryId = model.NewsCategoryId;
            Name = model.Name;
            Type = model.Type;
            Description = model.Description;
            Order = model.Order;
        }
        public NewsCategory(NewsCategoryModel model)
        {
            NewsCategoryId = model.NewsCategoryId;
            Name = model.Name;
            Type = model.Type;
            Description = model.Description;
            Order = model.Order;
        }
    }
    public class NewsCategoryModel
    {
        public Guid NewsCategoryId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int? Order { get; set; }
    }

    public class NewsCategoryFilter : BaseQueryFilter
    {
        public string Type { get; set; }
        public Guid? NewsCategoryId { get; set; }
    }

    public class NewsCategoryController : ApiController
    {
        [HttpGet]
        [Route("api/v1/newscategory/quantity")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public int GetQuantity()
        {
            using (var db = new cms_VKTTVEntities())
            {
                var quantity = db.cms_NewsCategory.Count();
                return quantity;
            }
        }

        [HttpGet]
        [Route("api/v1/newscategory")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<NewsCategory> GetAllNewsCatergory()
        {
            using (var db = new cms_VKTTVEntities())
            {
                var result = new List<NewsCategory>();
                var data = db.cms_NewsCategory.OrderBy(x => x.Type).ThenBy(x => x.Order);
                foreach (var item in data)
                {
                    result.Add(new NewsCategory(item));
                }
                return result;
            }
        }
        [HttpGet]
        [Route("api/v1/newscategory/filter")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<NewsCategory> FilterNewsCatergory(string filterString)
        {
            NewsCategoryFilter filter = JsonConvert.DeserializeObject<NewsCategoryFilter>(filterString);
            using (var db = new cms_VKTTVEntities())
            {
                var result = new List<NewsCategory>();
                var data = new List<cms_NewsCategory>();
                var datas = db.cms_NewsCategory;

                if(filter.NewsCategoryId != null)
                {
                    data = datas.Where(x => x.NewsCategoryId == filter.NewsCategoryId).ToList();
                    result.Add(new NewsCategory(data.FirstOrDefault()));
                    return result;
                }

                if (!string.IsNullOrEmpty(filter.Type))
                {
                    data = datas.Where(x => x.Type == filter.Type).ToList();
                }
                if (!string.IsNullOrEmpty(filter.FilterText))
                {
                    data = datas.Where(x => x.Description.Contains(filter.FilterText)
                    || x.Name.Contains(filter.FilterText)).ToList();
                }

                int excludedRow = (filter.PageNumber - 1) * filter.PageSize;
                data = data.Skip(excludedRow).Take(filter.PageSize).ToList();
                foreach (var item in data)
                {
                    result.Add(new NewsCategory(item));
                }
                return result;
            }
        }

        [HttpPost]
        [Route("api/v1/newscategory/create")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public NewsCategory Create([FromBody] NewsCategoryModel model)
        {
            //var model = JsonConvert.DeserializeObject<>(modelString);
            using (var db = new cms_VKTTVEntities())
            {
                db.cms_NewsCategory.Add(new cms_NewsCategory()
                {
                    NewsCategoryId = Guid.NewGuid(),
                    Description = model.Description,
                    Name = model.Name,
                    Type = model.Type,
                    Order = model.Order
                });
                db.SaveChanges();
                return new NewsCategory(model);
            }
        }

        [HttpPut]
        [Route("api/v1/newscategory/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public NewsCategory Update([FromBody]NewsCategoryModel model)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var data = db.cms_NewsCategory.Where(x => x.NewsCategoryId == model.NewsCategoryId).FirstOrDefault();
                data.Description = model.Description;
                data.Name = model.Name;
                data.Order = model.Order;
                data.Type = model.Type;
                db.SaveChanges();

                return new NewsCategory(model);
            }

        }

        [HttpDelete]
        [Route("api/v1/newscategory/delete")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public NewsCategory Delete(Guid id)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var data = db.cms_NewsCategory.Where(x => x.NewsCategoryId == id).FirstOrDefault();
                db.cms_NewsCategory.Remove(data);
                db.SaveChanges();

                return new NewsCategory(data);
            }
        }
    }
}
