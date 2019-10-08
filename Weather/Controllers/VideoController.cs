using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
                var data = await db.cms_Video.OrderBy(x => x.CreatedOnDate).ToListAsync();
                var result = new List<CMS_Video>();
                foreach (var dt in data)
                {
                    result.Add(new CMS_Video(dt));
                }
                return result;
            }
        }

        [HttpDelete]
        [Route("api/v1/videos/{id}")]
        public async Task<CMS_Video> DeleteVideo(string id)
        {
            using (var db = new cms_VKTTVEntities())
            {
                var data = db.cms_Video.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
                db.cms_Video.Remove(data);
                if(await db.SaveChangesAsync() >= 1)
                {
                    var path = System.Web.Hosting.HostingEnvironment.MapPath("~");
                }
                return new CMS_Video(data);
            }
        }
    }
}
