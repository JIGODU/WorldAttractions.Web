﻿using Microsoft.Extensions.DependencyInjection;
using WorldAttractionsExplorer.Services.Access;
using WorldAttractionsExplorer.Services.Contracts;

namespace WorldAttractionsExplorer.Services
{
    public static class ServiceCollection
    {
        public static void AddServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IAttractionService, AttractionService>();
        }
    }
}
