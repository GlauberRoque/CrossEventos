using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossEventos.Application;
using CrossEventos.Application.Contratos;
using CrossEventos.Persistence;
using CrossEventos.Persistence;
using CrossEventos.Persistence.Contexto;
using CrossEventos.Persistence.Contrato;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoMapper;

namespace CrossEventos.API;

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
            //String de conexão direta com autenticação via windows.
            services.AddDbContext<CrossEventosContext>(
                options => options.UseSqlServer("Data Source=DESKTOP-31T93GE;Initial Catalog=CrossEventos;Integrated Security=True;TrustServerCertificate=True")
            );
            services.AddControllers()
                    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
                                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);
                    
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IEventosService, EventoService>();
            services.AddScoped<IGeralPersist, GeralPersist>();
            services.AddScoped<IEventoPersist, EventoPersist>();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CrossEventos.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CrossEventos.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyOrigin()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
