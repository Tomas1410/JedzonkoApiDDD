using FluentValidation;
using FluentValidation.AspNetCore;
using Jedzonko.Api;
using Jedzonko.Api.BindingModels;
using Jedzonko.Api.Middlewares;
using Jedzonko.Data.Sql;
using Jedzonko.Data.Sql.Migrations;
using Jedzonko.Data.Sql.Rodzaj;
using Jedzonko.Data.Sql.Uzytkownik;
using Jedzonko.Domain.Uzytkownik;
using Jedzonko.IData.Rodzaj;
using Jedzonko.IData.Uzytkownik;
using Jedzonko.IServices.Rodzaj;
using Jedzonko.IServices.Uzytkownik;
using Jedzonko.Services.Rodzaje;
using Jedzonko.Services.Uzytkownik;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;
using System.Threading.Tasks;
using static Jedzonko.Api.BindingModels.EditUser;

namespace Foodly.Api
{
    public class Startup
    {
        //Reprezentuje zestaw w³aœciwoœci konfiguracyjnych aplikacji klucz / wartoœæ. (np z pliku appsettings.json)
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

     
        public void ConfigureServices(IServiceCollection services)
        {
            //rejestracja DbContextu, u¿ycie providera MySQL i pobranie danych o bazie z appsettings.json


            services.AddAuthentication("OAuth").AddJwtBearer("OAuth", config =>
             {
                 var secretBytes = Encoding.UTF8.GetBytes(Constants.Secret);
                 var key = new SymmetricSecurityKey(secretBytes);

                     config.TokenValidationParameters = new TokenValidationParameters()
                     {
                         
                         ValidIssuer = Constants.Issuer,
                         ValidAudience = Constants.Audiance,
                         IssuerSigningKey = key,
                     };
            });

            services.AddDbContext<JedzonkoDbContext>(options => options
                .UseMySQL(Configuration.GetConnectionString("JedzonkoDbContext")));
            services.AddTransient<DatabaseSeed>();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            })
            .AddFluentValidation();

            services.AddTransient<IValidator<EditUser>, EditUserValidator>();


            services.AddScoped<IUzytkownikService, UzytkownikService>();
            services.AddScoped<IUzytkownikRepository, UzytkownikRepository>();
            services.AddScoped<IRodzajRepository, RodzajRepository>();
            services.AddScoped<IRodzajService, RodzajService>();

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.UseApiBehavior = false;
            });
        }


        // Metoda w której konfiguruje siê pipeline (potok) ¿¹dañ HTTP.
        //Ja u¿y³em tej metody do upewnienia siê, ¿e baza któr¹ chce utworzyæ nie istnieje,
        //a nastêpnie do utworzenia bazy danych i utworzenia testowych danych

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<JedzonkoDbContext>();
                var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                databaseSeed.Seed();
            }
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}