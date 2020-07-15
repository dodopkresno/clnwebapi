using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MediatR;
using Web.Helper;
using Web.Interface;
using Web.Service;
using Infrastructure.Method;
using Core.Interface;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Filters;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
            }).AddXmlDataContractSerializerFormatters()
            .AddCustomCSVFormatter();

            services.AddApplication();
            //DI Application Setting
            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<ApplicationConfig>(appSettingSection);

            // configure jwt authentication
            var appSettings = appSettingSection.Get<ApplicationConfig>();
            var key = Encoding.ASCII.GetBytes(appSettings.secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Raport API PT TPS v1",
                    Version = "v1",
                    Description = "An API to perform Raport Operations",
                    Contact = new OpenApiContact
                    {
                        Name = "Helpdesk IT TPS",
                        Email = "Helpdesk@tps.co.id"
                    }
                });
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Raport API PT TPS v2",
                    Version = "v2",
                    Description = "An API to perform Raport Operations",
                    Contact = new OpenApiContact
                    {
                        Name = "Helpdesk IT TPS",
                        Email = "Helpdesk@tps.co.id"
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
                    Description = @"Authorization header Barier scheme. Masukan 'Bearer' [spasi] kemudian masukan kode token pada textbox dibawah. Contoh: 'Bearer 123tokencode'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //Add DI Class
            services.AddScoped<IAppConfig, AppConfigService>();
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(IOContext<>));
            services.AddScoped<ICoaMapRepository, CoaMapRepository>();

            //services.AddScoped<ICoaMapProfile, VMCoaMapDxos>();
            //services.AddScoped(typeof(IRepository<>), typeof(AbsIOfile<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TPS API v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "TPS API v2");
            });
            //app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseStaticFiles();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
