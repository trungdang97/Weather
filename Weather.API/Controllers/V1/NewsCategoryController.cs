using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Weather.Business.V1;
using Weather.Data.V1;
using Newtonsoft.Json;
using System.Net.Http;

namespace Weather.API.Controllers.V1
{
    public class NewsCategoryController : ApiControllerAttribute
    {
        private readonly INewsCategoryHandler _handler;
        public NewsCategoryController(INewsCategoryHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [Route("api/v1/newscategory/filter")]
        public Task<OldResponse<List<CMS_NewsCategory>>> GetFilter(string filter)
        {
            NewsCategoryFilterModel filterModel = JsonConvert.DeserializeObject<NewsCategoryFilterModel>(filter);
            return _handler.GetFilter(filterModel);
        }

        [HttpPost]
        [Route("api/v1/newscategory/create")]
        public Task<OldResponse<CMS_NewsCategory>> Create([FromBody]NewsCategoryCreateRequestModel model)
        {
            return _handler.Create(model);

        }

        [HttpPut]
        [Route("api/v1/newscategory/update")]
        public Task<OldResponse<CMS_NewsCategory>> Update([FromBody]NewsCategoryUpdateRequestModel model)
        {
            return _handler.Update(model);
        }

        [HttpDelete]
        [Route("api/v1/newscategory/delete/{id}")]
        public Task<OldResponse<NewsCategoryDeleteResponseModel>> Delete(Guid id)
        {
            return _handler.Delete(id);
        }

        [HttpDelete]
        [Route("api/v1/newscategory/deletemany")]
        public Task<OldResponse<List<NewsCategoryDeleteResponseModel>>> DeleteMany(List<Guid> listId)
        {
            return _handler.DeleteMany(listId);
        }
    }
}