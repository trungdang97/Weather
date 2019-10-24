using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Weather.Data;

namespace Weather.Controllers
{
    public class CMS_Video
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public string FullPath { get; set; }

        public CMS_Video(cms_Video model)
        {
            Id = model.Id;
            Name = model.Name;
            CreatedOnDate = model.CreatedOnDate;
            FullPath = model.FullPath;
        }
    }

    public class CMS_VideoCreateRequest
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
    }
    
    public class VideoController : ApiController
    {
        [HttpGet]
        [Route("api/v1/videos/newest")]
        public async Task<List<CMS_Video>> GetNewestVideos(int quantity)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var data = await db.cms_Video.OrderBy(x => x.CreatedOnDate).Take(quantity).ToListAsync();
                var result = new List<CMS_Video>();
                foreach(var dt in data)
                {
                    result.Add(new CMS_Video(dt));
                }
                return result;
            }
        }

        [HttpGet]
        [Route("api/v1/videos")]
        public async Task<List<CMS_Video>> GetVideos()
        {
            using (var db = new cms_VKTTVEntities())
            {
                var data = await db.cms_Video.OrderByDescending(x => x.CreatedOnDate).ToListAsync();
                var result = new List<CMS_Video>();
                foreach (var dt in data)
                {
                    result.Add(new CMS_Video(dt));
                }
                return result;
            }
        }

        [HttpPost]
        [Route("api/v1/videos/create")]
        public async Task<CMS_Video> CreateVideo([FromBody]CMS_VideoCreateRequest model)
        {
            using (var db = new cms_VKTTVEntities())
            {
                cms_Video video = new cms_Video()
                {
                    Id = Guid.NewGuid(),
                    CreatedOnDate = DateTime.Now,
                    Name = model.Name,
                    FullPath = model.FullPath
                };
                db.cms_Video.Add(video);
                if(await db.SaveChangesAsync() >= 1)
                {
                    
                }

                return new CMS_Video(video);
            }
        }

        [HttpPost]
        [Route("api/v1/videos/upload")]
        public void UploadVideo()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedVideo"];

                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)

                    // Get the complete file path
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/videos"), httpPostedFile.FileName);

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                }
            }
        }

        [HttpDelete]
        [Route("api/v1/videos/delete")]
        public async Task<CMS_Video> DeleteVideo(Guid id)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var data = db.cms_Video.Where(x => x.Id == id).FirstOrDefault();
                db.cms_Video.Remove(data);
                if(await db.SaveChangesAsync() >= 1)
                {
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/videos"), data.FullPath);
                    File.Delete(fileSavePath);
                }
                return new CMS_Video(data);
            }
        }

        [HttpPut]
        [Route("api/v1/videos/update")]
        public async Task<CMS_Video> UpdateVideo(Guid id, string name)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var data = db.cms_Video.Where(x => x.Id == id).FirstOrDefault();
                data.Name = name;
                if (await db.SaveChangesAsync() >= 1)
                {
                    return new CMS_Video(data);
                }
                return null;
            }
        }
    }
}
