﻿namespace CMSCore.Library.Authentication
{
    using Configuration;
    using Handlers;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddCMSCoreAuthentication(this IServiceCollection services, IAuthenticationConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = configuration.Domain;
                options.Audience = configuration.ApiIdentifier;
            });

            services.AddAuthorization(options => options.SetPolicies(configuration));

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            return services;
        }
        public static AuthorizationOptions SetPolicies(this AuthorizationOptions options, IAuthenticationConfiguration configuration)
        {
            var policiesInConfig = configuration.Policies;

            if (policiesInConfig != null)
            {
                foreach (var policyName in policiesInConfig)
                {
                    options.AddPolicy(policyName, policy => policy.Requirements.Add(new HasScopeRequirement(policyName, configuration.Domain)));
                }
            }

            return options;
        }

        public static IApplicationBuilder UseCMSCoreAuthentication(this IApplicationBuilder app)
        {
            var authenticationAdded = app.UseAuthentication();
            return authenticationAdded;
        }
    }
}