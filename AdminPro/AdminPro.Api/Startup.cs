using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPro.Api.Configurations.Extensions;
using AdminPro.Api.Interfaces;
using AdminPro.Api.Services;
using AdminPro.Core.Interfaces;
using AdminPro.Infrastructure.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace AdminPro.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _webHostEnvironment;



        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(jwtOptions =>
                {
                    //jwtOptions.Authority =  $"https://login.microsoftonline.com/tfp/{Configuration["AzureAdB2C:Tenant"]}/{Configuration["AzureAdB2C:SignUpSignInPolicyId"]}/v2.0/";
                    jwtOptions.Authority = Configuration["AzureAdB2C:Instance"] + Configuration["AzureAdB2C:Domain"] + "/" + Configuration["AzureAdB2C:SignUpSignInPolicyId"] + "/v2.0";
                    jwtOptions.Audience = Configuration["AzureAdB2C:ClientId"];
                    jwtOptions.SaveToken = true;
                    jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidAudience = jwtOptions.Audience,
                        ValidateIssuer = false,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        //IssuerValidator = (issuer, token, parameters) => _tokenValidator.Validate(issuer)
                    };
                    jwtOptions.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context => Task.CompletedTask,
                        OnChallenge = context => Task.CompletedTask,
                        OnAuthenticationFailed = (context) =>
                        {
                            Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("Validated: " + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization();

            var connectionString = Configuration["connectionStrings:adminprodb"];
            services.AddDbContext<DatabaseContext>(o => { o.UseSqlServer(connectionString); });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IUserViewModelService, UserViewModelService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseNewUserMiddleware();

        }
    }
}
