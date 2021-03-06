﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using CustomTokenAuthProvider;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ethereal_EM.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace Ethereal_EM
{
    public partial class Startup
    {
        public SymmetricSecurityKey signingKey;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.ConfigureCors();
            // services.AddSignalR(hubOptions =>
            //        {
            //            hubOptions.EnableDetailedErrors = true;
            //            hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(15);
            //        });
            services.AddSignalR();
            services.ConfigureIISIntegration();

            services.ConfigureMySqlContext(Configuration);

            services.ConfigureRepositoryWrapper();

            services.AddTransient<TokenProviderMiddleware>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSignalR();
            services.AddMvc()
            .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(30);
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwt =>
            {

                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value));
                jwt.TokenValidationParameters = new TokenValidationParameters
                {

                    // The signing key must match!
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    // Validate the JWT Issuer (iss) claim
                    ValidateIssuer = true,
                    ValidIssuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
                    // Validate the JWT Audience (aud) claim
                    ValidateAudience = true,
                    ValidAudience = Configuration.GetSection("TokenAuthentication:Audience").Value,
                    // Validate the token expiry
                    ValidateLifetime = true,
                    // If you want to allow a certain amount of clock drift, set that here:
                    ClockSkew = TimeSpan.Zero
                };
                string key = "JFTUFICUCQ4GS3MI6RBM39SD"; //TODO read data from config
                double expiretimespan = Convert.ToDouble(Configuration.GetSection("TokenAuthentication:TokenExpire").Value);

                jwt.SecurityTokenValidators.Clear();
                jwt.SecurityTokenValidators.Add(new OAuthTokenHandler(expiretimespan, key));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //Set for console log
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //Set for log4net
            loggerFactory.AddLog4Net(Configuration.GetValue<string>("Log4NetConfigFile:Name"));
            app.UseSession();
            //app.UseStaticFiles(); // For the wwwroot folder
            //app.UseS; // For the wwwroot folder
            // Serve my app-specific default file, if present.
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();
            //app.UseStaticFiles("");  
            //app.UsePathBase("/videocvadmin");
            // app.UseSignalR(routes =>
            //        {
            //            routes.MapHub<ChatHub>("api/chatHub");
            //        });
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All,
                RequireHeaderSymmetry = false,
                ForwardLimit = null,
                KnownProxies = { System.Net.IPAddress.Parse("172.31.130.61"), System.Net.IPAddress.Parse("127.0.0.1") },
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors("CorsAllowAllPolicy");

            app.UseAuthentication();
            app.UseSignalR(routes =>
           {
               routes.MapHub<ChatHub>("/Ethereal_EM/Util/chathub");
           });

            app.UseTokenProviderMiddleware();
            loggerFactory.AddConsole(LogLevel.Warning, true).AddDebug();

            app.UseMvcWithDefaultRoute();
        }

        private Task<ClaimsIdentity> GetIdentity(string username, string password)
        {

            return Task.FromResult(new ClaimsIdentity(new GenericIdentity(username, "Token"), new Claim[] { }));
        }
    }
}

