using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Business.V1;
using Weather.Data.V1;

namespace Weather.API.Controllers.V1.Aspnet
{
    public class UserRightController : ApiControllerAttribute
    {
        private readonly IUserRightHandler _handler;
        public UserRightController(IUserRightHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [Route("api/v1/idm_right/filter")]
        public Task<OldResponse<List<Idm_Right>>> GetFilter(string filter)
        {
            UserRightFilterModel filterModel = JsonConvert.DeserializeObject<UserRightFilterModel>(filter);
            return _handler.GetFilter(filterModel);
        }

        [HttpPost]
        [Route("api/v1/idm_right/create")]
        public Task<OldResponse<Idm_Right>> Create([FromBody]UserRightCreateRequestModel model)
        {
            return _handler.Create(model);
        }

        [HttpPut]
        [Route("api/v1/idm_right/update")]
        public Task<OldResponse<Idm_Right>> Update([FromBody]UserRightUpdateRequestModel model)
        {
            return _handler.Update(model);
        }

        [HttpDelete]
        [Route("api/v1/idm_right/delete/{id}")]
        public Task<OldResponse<UserRightDeleteResponseModel>> Delete(string code)
        {
            return _handler.Delete(code);
        }
    }
}
