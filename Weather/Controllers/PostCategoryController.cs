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
    public class PostCategoryController : ApiController
    {
        private readonly cms_VKTTVEntities db = new cms_VKTTVEntities();

        [HttpGet]
        [Route("api/v1/postcategory/all")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<PostCategory> GetAll()
        {
            var data = db.cms_PostCategory.Select(PostCategoryConverter.PostCategoryConvert).ToList();

            return data;
        }

        [HttpPost]
        [Route("api/v1/postcategory/create")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Create([FromBody]PostCategoryCreateRequestModel model)
        {
            try
            {
                cms_PostCategory category = new cms_PostCategory()
                {
                    PostCategoryId = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description
                };
                db.cms_PostCategory.Add(category);

                int status = db.SaveChanges();
                return status.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPut]
        [Route("api/v1/postcategory/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Update([FromBody]PostCategoryUpdateRequestModel model)
        {
            try
            {
                var category = db.cms_PostCategory.Where(x => x.PostCategoryId == model.PostCategoryId).First();
                category.Name = model.Name;
                category.Description = model.Description;

                int status = db.SaveChanges();
                return status.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete]
        [Route("api/v1/postcategory/delete")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Delete(Guid PostCategoryId)
        {
            try
            {
                var category = db.cms_PostCategory.Where(x => x.PostCategoryId == PostCategoryId).First();
                db.cms_PostCategory.Remove(category);

                int status = db.SaveChanges();
                return status.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

    // POST CATEGORY MODELS
    public class PostCategory
    {
        public Guid PostCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class PostCategoryCreateRequestModel
    {
        //public Guid PostCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class PostCategoryUpdateRequestModel
    {
        public Guid PostCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public static class PostCategoryConverter
    {
        public static PostCategory PostCategoryConvert(cms_PostCategory category)
        {
            return new PostCategory()
            {
                PostCategoryId = category.PostCategoryId,
                Name = category.Name,
                Description = category.Description
            };
        }
    }
}