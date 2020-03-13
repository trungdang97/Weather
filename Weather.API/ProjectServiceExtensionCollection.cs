using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Business.V1;

namespace Weather.API
{
    public static class ProjectServiceExtensionCollection
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services) =>
            services
            .AddSingleton<INewsCategoryHandler, DbNewsCategoryHandler>();
    }
}
