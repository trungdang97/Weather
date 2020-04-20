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
    public class UserRoleController : ApiControllerAttribute
    {
        private readonly IUserRoleHandler _handler;
        public UserRoleController(IUserRoleHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [Route("api/v1/user_role/filter")]
        public Task<OldResponse<List<AspnetRoles>>> GetFilter(string filter)
        {
            UserRoleFilterModel filterModel = JsonConvert.DeserializeObject<UserRoleFilterModel>(filter);
            return _handler.GetFilter(filterModel);
        }

        [HttpPost]
        [Route("api/v1/user_role/create")]
        public Task<OldResponse<AspnetRoles>> Create([FromBody]UserRoleCreateRequestModel model)
        {
            return _handler.Create(model);
        }

        [HttpPut]
        [Route("api/v1/user_role/update")]
        public Task<OldResponse<AspnetRoles>> Update([FromBody]UserRoleUpdateRequestModel model)
        {
            return _handler.Update(model);
        }

        [HttpDelete]
        [Route("api/v1/user_role/delete/{id}")]
        public Task<OldResponse<UserRoleDeleteResponseModel>> Delete(Guid id)
        {
            //return _handler.Delete(id);
            throw new NotImplementedException();
        }
    }
}
