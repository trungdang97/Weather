using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Business.V1;
using Weather.Data.V1;

namespace Weather.API.Controllers.V1
{
    public class NavigationController : ApiControllerAttribute
    {
        private readonly INavigationHandler _handler;
        public NavigationController(INavigationHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [Route("api/v1/navigation/filter")]
        public Task<OldResponse<List<Navigation>>> GetFilter(string filter)
        {
            NavigationFilterModel filterModel = JsonConvert.DeserializeObject<NavigationFilterModel>(filter);
            return _handler.GetFilter(filterModel);
        }

        [HttpPost]
        [Route("api/v1/navigation/create")]
        public Task<OldResponse<Navigation>> Create([FromBody]NavigationCreateRequestModel model)
        {
            return _handler.Create(model);

        }

        [HttpPut]
        [Route("api/v1/navigation/update")]
        public Task<OldResponse<Navigation>> Update([FromBody]NavigationUpdateRequestModel model)
        {
            return _handler.Update(model);
        }

        [HttpDelete]
        [Route("api/v1/navigation/delete/{id}")]
        public Task<OldResponse<NavigationDeleteResponseModel>> Delete(Guid id)
        {
            return _handler.Delete(id);
        }

        //[HttpDelete]
        //[Route("api/v1/navigation/deletemany")]
        //public Task<OldResponse<List<NavigationDeleteResponseModel>>> DeleteMany([FromBody]List<Guid> listId)
        //{
        //    return _handler.DeleteMany(listId);
        //}
    }
}
