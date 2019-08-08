using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Weather.Data;

namespace Weather.Controllers
{
    public class PostController : ApiController
    {
        private readonly cms_VKTTVEntities db = new cms_VKTTVEntities();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }        

        // POST api/<controller>
        public string Create([FromBody]PostCreateRequestModel model)
        {
            try
            {
                cms_Post post = new cms_Post()
                {
                    PostId = Guid.NewGuid(),
                    Title = model.Title,
                    Body = model.Body,
                    CreatedOnDate = DateTime.UtcNow.AddHours(7),
                    LastUpdatedOnDate = DateTime.UtcNow.AddHours(7),
                    PostCategoryId = model.PostCategoryId,
                    UserId = model.UserId
                };

                db.cms_Post.Add(post);
                int status = db.SaveChanges();

                return status.ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<controller>/5
        public void Update(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    //MODELS
    // POST MODELS
    public class Post
    {
        public Guid PostId { get; set; }
        public Guid PostCategoryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public DateTime LastUpdatedOnDate { get; set; }
        public Guid UserId { get; set; }
        public bool IsApproved { get; set; }


    }

    public class PostCreateRequestModel
    {
        //public Guid PostId { get; set; }
        public Guid PostCategoryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        //public DateTime CreatedOnDate { get; set; }
        //public DateTime LastUpdatedOnDate { get; set; }
        public Guid UserId { get; set; }
        //public bool IsApproved { get; set; }
    }

    public class PostUpdateRequestModel
    {
        public Guid PostId { get; set; }
        public Guid PostCategoryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        //public DateTime CreatedOnDate { get; set; }
        //public DateTime LastUpdatedOnDate { get; set; }
        //public Guid UserId { get; set; }
        //public bool IsApproved { get; set; }
    }

    public static class PostConverter
    {
        public static Post PostConvert(cms_Post post)
        {
            return new Post()
            {
                PostId = post.PostId,
                Title = post.Title,
                Body = post.Body,
                CreatedOnDate = post.CreatedOnDate,
                LastUpdatedOnDate = post.LastUpdatedOnDate,
                IsApproved = post.IsApproved,
                PostCategoryId = post.PostCategoryId,
                UserId = post.UserId
            };
        }
    }
}