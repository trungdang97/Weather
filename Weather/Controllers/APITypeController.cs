using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Weather.Data;

namespace Weather.Controllers
{
    public class APITypeFilter
    {
        public string FilterText { get; set; }
    }

    public class APITypeController : ApiController
    {
        private cms_VKTTVEntities db = new cms_VKTTVEntities();

        // GET: api/APIType
        [HttpGet]
        [Route("api/v1/APIType/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public cms_APIType GetById(Guid APITypeId)
        {
            var model = db.cms_APIType.Where(x => x.APITypeId == APITypeId).First();
            return model;
        }

        // GET: api/APIType/5
        [HttpGet]
        [Route("api/v1/APIType/{filterText}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<cms_APIType> GetFilter(string filterText)
        {
            var models = db.cms_APIType.Where(x => x.Name.Contains(filterText));
            return models.ToList();
        }

        // PUT: api/APIType/5
        [HttpPut]
        [Route("api/v1/APIType/update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public cms_APIType Update([FromBody]cms_APIType APIType)
        {
            var model = db.cms_APIType.Where(x => x.APITypeId == APIType.APITypeId).First();
            model.Name = APIType.Name;
            db.SaveChanges();
            model = db.cms_APIType.Where(x => x.APITypeId == APIType.APITypeId).First();

            return model;
        }

        // POST: api/APIType
        [HttpPost]
        [Route("api/v1/APIType/create")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public cms_APIType Create(string name)
        {
            cms_APIType model = new cms_APIType()
            {
                APITypeId = Guid.NewGuid(),
                Name = name
            };
            db.cms_APIType.Add(model);
            db.SaveChanges();

            return model;
        }

        [HttpDelete]
        [Route("api/v1/APIType/delete/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public cms_APIType Delete(Guid id)
        {
            var model = db.cms_APIType.Where(x => x.APITypeId == id).First();
            if(model != null)
            {
                db.cms_APIType.Remove(model);
                db.SaveChanges();
                return model;
            }
            return null;
        }        
    }
}