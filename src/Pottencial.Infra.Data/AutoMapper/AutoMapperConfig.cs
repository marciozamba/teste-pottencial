using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Infra.Data.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ProfileBase));
        }
    }
}
