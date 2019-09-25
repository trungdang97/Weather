using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.V1;

namespace Weather.Business.V1
{
    public interface INewsHandler
    {
        Task<OldResponse<List<CMS_News>>> GetFilter(NewsFilterModel filter);
        Task<OldResponse<CMS_News>> Create(NewsCreateRequestModel model);
        Task<OldResponse<CMS_News>> Update(NewsUpdateRequestModel model);
        Task<OldResponse<NewsDeleteResponseModel>> Delete(Guid id);
        Task<OldResponse<List<NewsDeleteResponseModel>>> DeleteMany(List<Guid> listId);
    }
}
