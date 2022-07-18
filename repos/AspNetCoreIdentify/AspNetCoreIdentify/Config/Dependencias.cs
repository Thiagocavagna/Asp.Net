﻿using AspNetCoreIdentity.Extensions;
using KissLog;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreIdentity.Config
{
    public static class Dependencias
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, PermissaoNecessariaHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(context => Logger.Factory.Get());

            services.AddScoped<AuditoriaFilter>();


            return services;
        }
    }
}
