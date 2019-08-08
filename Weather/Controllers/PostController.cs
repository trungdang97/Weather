using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Weather.Data;
using Weather.Login;

namespace Weather.Controllers
{
    public class PostController : ApiController
    {
        private readonly cms_VKTTVEntities db = new cms_VKTTVEntities();

        [HttpGet]
        [Route("api/v1/post")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Post GetById(Guid PostId)
        {
            try
            {
                var data = db.cms_Post.Where(x => x.PostId == PostId).First();

                var result = PostConverter.PostConvert(data);
                var user = db.aspnet_Membership.Where(x => x.UserId == result.UserId).First();
                result.User = new User()
                {
                    FullName = user.FullName,
                    ShortName = user.ShortName,
                };

                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/v1/post/filter")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<Post> GetFilter(string Filter)
        {
            try
            {
                PostFilter filter = JsonConvert.DeserializeObject<PostFilter>(Filter);

                var data = db.cms_Post.Where(x =>
                    x.Title.Contains(filter.FilterText) || x.Body.Contains(filter.FilterText));
                if (filter.PostCategoryId.HasValue)
                {
                    data = data.Where(x => x.PostCategoryId == filter.PostCategoryId);
                }
                //if(filter.StartDate != null && filter.EndDate != null)
                //{
                //    data = data.Where(x=>x.CreatedOnDate)
                //}
                data = data.OrderByDescending(x => x.CreatedOnDate);

                int excludedRows = (filter.PageNumber - 1) * filter.PageSize;
                data = data.Skip(excludedRows).Take(filter.PageSize);

                var result = data.Select(PostConverter.PostConvert).ToList();
                foreach(var r in result)
                {
                    var user = db.aspnet_Membership.Where(x => x.UserId == r.UserId).First();
                    r.User = new User()
                    {
                        FullName = user.FullName,
                        ShortName = user.ShortName,
                    };
                }

                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/v1/post/create")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
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
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPut]
        [Route("api/v1/post/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Update([FromBody]PostUpdateRequestModel model)
        {
            try
            {
                var post = db.cms_Post.Where(x => x.PostId == model.PostId).First();
                post.Title = model.Title;
                post.PostCategoryId = model.PostCategoryId;
                post.Body = model.Body;
                post.LastUpdatedOnDate = DateTime.UtcNow.AddHours(7);
                int status = db.SaveChanges();

                return status.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete]
        [Route("api/v1/post/delete")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Delete(Guid PostId)
        {
            try
            {
                var post = db.cms_Post.Where(x => x.PostId == PostId).First();
                db.cms_Post.Remove(post);
                int status = db.SaveChanges();

                return status.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

    //MODELS
    // POST MODELS
    public class Post
    {
        public Guid PostId { get; set; }
        public Guid? PostCategoryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public DateTime LastUpdatedOnDate { get; set; }
        public Guid? UserId { get; set; }
        public bool IsApproved { get; set; }

        public User User { get; set; }
    }

    public class PostFilter
    {
        //public Guid PostId { get; set; }
        public Guid? PostCategoryId { get; set; }
        public string FilterText { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //public string Body { get; set; }
        //public DateTime CreatedOnDate { get; set; }
        //public DateTime LastUpdatedOnDate { get; set; }
        //public Guid UserId { get; set; }
        //public bool IsApproved { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }

    public class PostCreateRequestModel
    {
        //public Guid PostId { get; set; }
        public Guid? PostCategoryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        //public DateTime CreatedOnDate { get; set; }
        //public DateTime LastUpdatedOnDate { get; set; }
        public Guid? UserId { get; set; }
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