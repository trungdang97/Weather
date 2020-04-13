//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using Weather.Data.V1;

//namespace Weather.Business.V1.Logic
//{
//    public class DbUserRoleHandler : IUserRoleHandler
//    {
//        public Task<OldResponse<AspnetRoles>> Create(UserRoleCreateRequestModel model)
//        {
//            try
//            {
//                using (var unitOfWork = new UnitOfWork())
//                {
//                    var data = AutoMapperUtils.AutoMap<UserRoleCreateRequestModel, AspnetRoles>(model);
//                    data.RoleId = Guid.NewGuid();
//                    data.
//                }
//            }
//            catch(Exception ex)
//            {

//            }
//        }

//        public Task<OldResponse<UserRoleDeleteResponseModel>> Delete(Guid id)
//        {
//            try
//            {
//                using (var unitOfWork = new UnitOfWork())
//                {
                    
//                }
//            }
//            catch (Exception ex)
//            {

//            }
//        }

//        public Task<OldResponse<List<UserRoleDeleteResponseModel>>> DeleteMany(List<Guid> listId)
//        {
//            try
//            {
//                using (var unitOfWork = new UnitOfWork())
//                {

//                }
//            }
//            catch (Exception ex)
//            {

//            }
//        }

//        public Task<OldResponse<List<AspnetRoles>>> GetFilter(UserRoleFilterModel filter)
//        {
//            try
//            {
//                using (var unitOfWork = new UnitOfWork())
//                {

//                }
//            }
//            catch (Exception ex)
//            {

//            }
//        }

//        public Task<OldResponse<AspnetRoles>> Update(UserRoleUpdateRequestModel model)
//        {
//            try
//            {
//                using (var unitOfWork = new UnitOfWork())
//                {

//                }
//            }
//            catch (Exception ex)
//            {

//            }
//        }
//    }
//}
