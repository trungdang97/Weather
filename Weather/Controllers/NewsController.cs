using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Weather.Data;
using static Weather.CMS.NewsForm;

namespace Weather.Controllers
{
    public class NewsCategory
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; } = 0;
    }

    public static class ConvertData
    {
        public static News ConvertNews(cms_News data)
        {
            return new News()
            {
                NewsId = data.NewsId,
                NewsCategoryId = data.NewsCategory,
                NewsCategoryName = data.cms_NewsCategory.Name,
                Name = data.Name,
                Location = data.Location,
                CreatedOnDate = data.CreatedOnDate,
                Writer = data.WriterName,
                Introduction = data.Introduction,
                Body = data.Body,
                ApproveStatus = data.ApprovedStatus,
                Thumbnail = data.Thumbnail
            };
        }
    }

    public class NewsController : ApiController
    {
        [HttpGet]
        [Route("api/v1/news")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public News GetById(Guid NewsId)
        {
            using (var db = new cms_VKTTVEntities())
            {
                IQueryable<cms_News> query = null;
                query = db.cms_News.Where(x => x.NewsId == NewsId);
                return query.Select(ConvertData.ConvertNews).First();
            }
        }

        [HttpPost]
        [Route("api/v1/news/filter")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<News> GetFilter([FromBody]Filter filter)
        {
            using (var db = new cms_VKTTVEntities())
            {
                aspnet_Membership User = null;
                if (filter.UserId.HasValue)
                {
                    User = db.aspnet_Membership.Where(x => x.UserId == filter.UserId.Value).First();
                }
                List<cms_News> query = new List<cms_News>();

                if (User == null)
                {
                    query = db.cms_News.ToList();
                }
                else if (User.aspnet_Roles.Description == "QTHT")
                {
                    query = db.cms_News.ToList();
                }
                else
                {
                    query = db.cms_News.Where(x => x.CreatedByUserId == filter.UserId).ToList();
                }

                if (!filter.IsCMS)
                {
                    query = query.Where(x => x.ApprovedStatus == true).ToList();
                }

                query = query.OrderByDescending(x => x.CreatedOnDate).ToList();
                if (filter.NewsCategoryId.HasValue)
                    query = query.Where(x => x.NewsCategory == filter.NewsCategoryId.Value).ToList();
                if (filter.FilterText != "")
                    query = query.Where(x => x.Name.Contains(filter.FilterText)).ToList();
                if (filter.FromDate.HasValue && filter.ToDate.HasValue)
                    query = query.Where(x => x.CreatedOnDate >= filter.FromDate && x.CreatedOnDate <= filter.ToDate).ToList();



                int excludedRow = (filter.PageNumber - 1) * filter.PageSize;
                return query.Skip(excludedRow).Take(filter.PageSize).Select(ConvertData.ConvertNews).ToList();
            }
        }

        [HttpGet]
        [Route("api/v1/news/quantity/total")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public int GetTotalQuantity(Guid? newsCategoryId)
        {
            using(var db = new cms_VKTTVEntities())
            {
                if(newsCategoryId == null)
                {
                    return db.cms_News.Where(x=> x.ApprovedStatus == true).Count();
                }
                return db.cms_News.Where(x => x.NewsCategory == newsCategoryId && x.ApprovedStatus == true).Count();
            }
            
        }


        [HttpPost]
        [Route("api/v1/news/add")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public void Post([FromBody]News data)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var model = new cms_News()
                {
                    NewsId = Guid.NewGuid(),
                    Name = data.Name,
                    Location = data.Location,
                    NewsCategory = data.NewsCategoryId,
                    //FinishDate = data.FinishDate,
                    CreatedByUserId = data.CreatedByUserId,
                    WriterName = db.aspnet_Membership.Where(x => x.UserId == data.CreatedByUserId).First().ShortName,
                    Body = data.Body,
                    Introduction = data.Introduction,
                    CreatedOnDate = data.CreatedOnDate,
                    ApprovedStatus = false,
                    Thumbnail = data.Thumbnail
                };

                db.cms_News.Add(model);
                db.SaveChanges();
            }
        }

        [HttpPut]
        [Route("api/v1/news/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public void Put([FromBody]News data)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var model = db.cms_News.Where(x => x.NewsId == data.NewsId).First();

                model.Name = data.Name;
                model.Location = data.Location;
                model.NewsCategory = data.NewsCategoryId;
                //model.FinishedDate = data.FinishedDate;
                //model.WriterName = db.aspnet_Membership.Where(x => x.UserId == UserId).First().ShortName;
                model.Body = data.Body;
                model.Introduction = data.Introduction;
                model.CreatedOnDate = data.CreatedOnDate;
                //model.ApprovedStatus = false;
                model.Thumbnail = data.Thumbnail;

                db.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("api/v1/news/delete")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public void Delete(Guid NewsId)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var model = db.cms_News.Where(x => x.NewsId == NewsId).First();
                db.cms_News.Remove(model);
                db.SaveChanges();
            }
        }

        [HttpGet]
        [Route("api/v1/news/category")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<NewsCategory> GetCategories(string Type)
        {
            using (var db = new cms_VKTTVEntities())
            {
                List<NewsCategory> categories = new List<NewsCategory>();
                var models = db.cms_NewsCategory.Where(x => x.Type == Type).OrderBy(x => x.Order);
                foreach (var m in models)
                {
                    categories.Add(new NewsCategory()
                    {
                        Name = m.Name,
                        Description = m.Description,
                        Type = m.Type
                    });
                }
                return categories;
            }
        }

        [HttpGet]
        [Route("api/v1/news/category/quantity")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<NewsCategory> GetCategoriesQuantity()
        {
            using (var db = new cms_VKTTVEntities())
            {
                List<NewsCategory> categories = new List<NewsCategory>();
                var models = db.cms_NewsCategory;
                foreach (var m in models)
                {
                    var quantity = db.cms_News.Where(x => x.NewsCategory == m.NewsCategoryId && x.ApprovedStatus == true).Count();
                    categories.Add(new NewsCategory()
                    {
                        Name = m.Name,
                        Description = m.Description,
                        Type = m.Type,
                        Quantity = quantity
                    });
                }
                return categories;
            }
        }

        [HttpGet]
        [Route("api/v1/news/category/recent")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<News> GetRecentNews(int quantity, Guid? NewsId, Guid? Category)
        {
            using (var db = new cms_VKTTVEntities())
            {
                List<News> lstNews = new List<News>();
                var models = (IQueryable<cms_News>)db.cms_News;
                if (Category.HasValue)
                {
                    models = db.cms_News.Where(x => x.NewsCategory == Category);
                }
                if (NewsId.HasValue)
                {
                    models = models.Where(x => x.NewsId != NewsId);
                }
                models = models.OrderByDescending(x => x.CreatedOnDate);

                models = models.Where(x => x.ApprovedStatus == true);

                if (models.Count() > quantity)
                {
                    models = models.Take(quantity);
                }

                lstNews.AddRange(models.Select(ConvertData.ConvertNews));

                return lstNews;
            }
        }

        [HttpPut]
        [Route("api/v1/news/visible")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public News ToggleVisible(Guid NewsId)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var query = db.cms_News.Where(x => x.NewsId == NewsId).First();
                query.ApprovedStatus = !query.ApprovedStatus;
                db.SaveChanges();

                return ConvertData.ConvertNews(query);
            }
        }
    }
}