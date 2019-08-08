using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Weather.Data;

namespace Weather.Controllers
{
    public class CommentController : ApiController
    {
        private readonly cms_VKTTVEntities db = new cms_VKTTVEntities();
        //NEWS
        [HttpGet]
        [Route("api/v1/comment/news")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<Comment> GetNewsComment(Guid NewsId)
        {
            List<Comment> comments = new List<Comment>();

            var data = db.cms_Comment.Where(x => x.ThreadId == NewsId && x.Type == "NEWS" && x.CommentParentId == null).OrderBy(x => x.CreatedOnDate).Select(CommentConverter.CommentConvert).ToList();
            foreach(var c in data)
            {
                c.Subcomments = new List<Comment>();
                c.Subcomments = db.cms_Comment.Where(x => x.ThreadId == NewsId && x.Type == "NEWS" && x.CommentParentId == c.CommentId).Select(CommentConverter.CommentConvert).OrderBy(x=>x.CreatedOnDate).ToList();
            }

            comments = data;
            return comments;
        }

        //POST
        [HttpGet]
        [Route("api/v1/comment/post")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<Comment> GetPostComment(Guid PostId)
        {
            List<Comment> comments = new List<Comment>();

            var data = db.cms_Comment.Where(x => x.ThreadId == PostId && x.Type == "NEWS").Select(CommentConverter.CommentConvert).ToList();
            foreach (var c in data)
            {
                c.Subcomments = new List<Comment>();
                c.Subcomments = db.cms_Comment.Where(x => x.ThreadId == PostId && x.Type == "NEWS" && x.CommentParentId == c.CommentId).Select(CommentConverter.CommentConvert).ToList();
            }

            comments = data;
            return comments;
        }

        // Dùng chung các cái khác
        [HttpPost]
        [Route("api/v1/comment/create")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Post([FromBody]CommentCreateRequestModel comment)
        {
            try
            {
                cms_Comment cm = new cms_Comment()
                {
                    CommentId = Guid.NewGuid(),
                    ThreadId = comment.ThreadId,
                    CommentParentId = comment.CommentParentId,
                    Type = comment.Type,
                    Title = string.IsNullOrEmpty(comment.Title) ? "" : comment.Title,
                    Body = comment.Body,
                    CreatedOnDate = DateTime.UtcNow.AddHours(7),
                    LastUpdatedOnDate = DateTime.UtcNow.AddHours(7),
                    UserId = comment.UserId,
                    UserName = string.IsNullOrEmpty(comment.UserName) ? "" : comment.UserName,
                    Email = string.IsNullOrEmpty(comment.Email) ? "" : comment.Email
                };
                if(cm.CommentParentId != null)
                {
                    var checkParent = db.cms_Comment.Where(x => x.CommentId == cm.CommentParentId).First();
                    if(checkParent.CommentParentId != null)
                    {
                        cm.CommentParentId = checkParent.CommentParentId;
                    }
                }
                
                db.cms_Comment.Add(cm);
                int status = db.SaveChanges();

                return status.ToString();
            }
            catch (DbEntityValidationException ex)
            {
                return ex.Message;
            }
        }

        [HttpPut]
        [Route("api/v1/comment/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Put([FromBody]CommentUpdateRequestModel comment)
        {
            try
            {
                var cm = db.cms_Comment.Where(x => x.CommentId == comment.CommentId).First();
                cm.LastUpdatedOnDate = DateTime.UtcNow.AddHours(7);
                cm.Body = comment.Body;

                int status = db.SaveChanges();
                return status.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPut]
        [Route("api/v1/comment/delete")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Delete(Guid CommentId)
        {
            try
            {
                var cm = db.cms_Comment.Where(x => x.CommentId == CommentId).First();
                db.cms_Comment.Remove(cm);
                int status = db.SaveChanges();
                return status.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

    // COMMENT MODELS
    public class Comment
    {
        public Guid CommentId { get; set; }
        public Guid? ThreadId { get; set; }
        public Guid? CommentParentId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public DateTime LastUpdatedOnDate { get; set; }
        public Guid? UserId { get; set; }
        public bool IsApprove { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<Comment> Subcomments { get; set; }
    }

    public class CommentCreateRequestModel
    {
        //public Guid CommentId { get; set; }
        public Guid ThreadId { get; set; }
        public Guid? CommentParentId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        //public DateTime CreatedOnDate { get; set; }
        //public DateTime LastUpdatedOnDate { get; set; }
        public Guid? UserId { get; set; }
        //public bool IsApprove { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class CommentUpdateRequestModel
    {
        public Guid CommentId { get; set; }
        //public Guid ThreadId { get; set; }
        //public Guid CommentParentId { get; set; }
        //public string Type { get; set; }
        //public string Title { get; set; }
        public string Body { get; set; }
        //public DateTime CreatedOnDate { get; set; }
        //public DateTime LastUpdatedOnDate { get; set; }
        //public Guid? UserId { get; set; }
        //public bool IsApprove { get; set; }
        //public string UserName { get; set; }
        //public string Email { get; set; }
    }

    public static class CommentConverter
    {
        public static Comment CommentConvert(cms_Comment comment)
        {
            Comment cm = new Comment()
            {
                CommentId = comment.CommentId,
                ThreadId = comment.ThreadId,
                CommentParentId = comment.CommentParentId,
                Type = comment.Type,
                Title = comment.Title,
                Body = comment.Body,
                CreatedOnDate = comment.CreatedOnDate,
                LastUpdatedOnDate = comment.LastUpdatedOnDate,
                UserId = comment.UserId,
                IsApprove = comment.IsApproved,
                UserName = comment.UserName,
                Email = comment.Email
            };

            return cm;
        }
    }

    
}