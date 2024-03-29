﻿using AspNetCoreIdentity.Areas.Identity.Data;
using AspNetCoreIdentity.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreIdentity.Config
{
    public static class Identity
    {
        public static IServiceCollection AddAuthorizationConfig(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("PodeExcluir", policy => policy.RequireClaim("PodeExcluir"));

                options.AddPolicy("PodeLer", policy => policy.Requirements.Add(new PermissaoNecessaria("")));
                options.AddPolicy("PodeEscrever", policy => policy.Requirements.Add(new PermissaoNecessaria("")));
            });
            return services;
        }
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // Politica de cookies (LGPD)
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Adicionando suporte ao contexto do Identity via EF
            services.AddDbContext<AspNetCoreIdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AspNetCoreIdentityContextConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //.AddDefaultUI(UIFramwork.Bootstrap4)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AspNetCoreIdentityContext>(); ;
            return services;
        }
    }
}
