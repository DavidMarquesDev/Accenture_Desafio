using Application.Application;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfacesServices;
using Domain.Services;
using Entities.Entities;
using Infrastructure.Config;
using Infrastructure.Repository;
using Infrastructure.Repository.Generics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebAPI.Token;

namespace WebAPI
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

            services.AddCors();
            services.AddDbContext<Context>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<Context>();

            // INTERFACE E REPOSITORIO
            services.AddSingleton(typeof(IGenerics<>), typeof(GenericsRepository<>));
            services.AddSingleton<IEmpresa, EmpresaRepository>();
            services.AddSingleton<IFornecedor, FornecedorRepository>();
            services.AddSingleton<IEmpresaFornecedor, EmpresaFornecedorRepository>();
            services.AddSingleton<ICep, CepRepository>();
            services.AddSingleton<IUsers, UserRepository>();

            // SERVIÇO DOMINIO
            services.AddSingleton<IEmpresaServices, EmpresaServices>();
            services.AddSingleton<IFornecedorServices, FornecedorServices>();
            services.AddSingleton<IEmpresaFornecedorServices, EmpresaFornecedorServices>();
            services.AddSingleton<ICepServices, CepServices>();

            // INTERFACE APLICAÇÃO
            services.AddSingleton<IEmpresaApplication, EmpresaApplication>();
            services.AddSingleton<IFornecedorApplication, FornecedorApplication>();
            services.AddSingleton<IEmpresaFornecedorApplication, EmpresaFornecedorApplication>();
            services.AddSingleton<ICepApplication, CepApplication>();
            services.AddSingleton<IUsersApplication, UserApplication>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(option =>
       {
           option.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = false,
               ValidateAudience = false,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,

               ValidIssuer = "Teste.Securiry.Bearer",
               ValidAudience = "Teste.Securiry.Bearer",
               IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
           };

           option.Events = new JwtBearerEvents
           {
               OnAuthenticationFailed = context =>
               {
                   Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                   return Task.CompletedTask;
               },
               OnTokenValidated = context =>
               {
                   Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                   return Task.CompletedTask;
               }
           };
       });



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });

                // Adiciona os comentários XML gerados pelo Visual Studio
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region Novo
            var urlCliente3 = "http://localhost:4200";
            app.UseCors(x => x
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader().WithOrigins(urlCliente3));
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

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