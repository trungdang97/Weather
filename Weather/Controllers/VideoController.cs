using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                var data = await db.cms_Video.OrderBy(x => x.CreatedOnDate).ToListAsync();
                var result = new List<CMS_Video>();
                foreach(var dt in data)
                {
                    result.Add(new CMS_Video(dt));
                }
                return result;
            }
        }
    }
}
