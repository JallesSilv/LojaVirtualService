using Dominio.Contratos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repositorio.Config;
using Repositorio.Contexto;
using Repositorio.Migrations.Base;
using Repositorio.Repository;

namespace LojaVirtualWS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("configuracoes.json", optional: false, reloadOnChange: true);

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();

            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var conn = FactoryConnection.connection;
            services.AddControllers();

            services.AddDbContext<LojaVirtualDbContext>(options => options.UseLazyLoadingProxies().UseMySql(conn).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddControllersWithViews();

                        
            services.AddScoped<IProdutosRepository, ProdutosRepository>();
            services.AddScoped<IPessoasRepository, PessoasRepository>();
            services.AddScoped<IPedidosRepository, PedidosRepository>();


            services.AddTransient<RodarMigration>();

            services.AddControllers().AddNewtonsoftJson();

            services.AddControllers()
                    .AddNewtonsoftJson(opt =>
                        opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors(c =>
            {
                c.AddPolicy("AlowsCors", options => {
                    options.AllowAnyOrigin()
                    .WithMethods("GET", "PUT", "POST", "DELETE")
                    .AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(wag =>
            {

                wag.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Loja Virtual", Version = VersaoApi.VersaoWeb });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc(option =>
            {
                option.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });

            app.UseSwagger(v => v.SerializeAsV2 = true);
            app.UseSwagger();
            app.UseSwaggerUI(swa => {
                swa.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Loja Virtual");
                swa.RoutePrefix = string.Empty;
            });

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            //Migration
            var serviceProv = app.ApplicationServices;
            var rodarMigration = serviceProv.GetService<RodarMigration>();
            rodarMigration.Executar();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
