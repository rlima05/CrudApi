using AutoMapper;
using CrudApi.Application;
using CrudApi.Application.Interface;
using CrudApi.Domain.Interface.Repositories;
using CrudApi.Domain.Interface.Services;
using CrudApi.Domain.Services;
using CrudApi.Infra;
using CrudApi.Infra.Repositories;
using CrudApi.Models.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace CrudApi
{
    public class Startup
    {

        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Redis
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration =
                    Configuration.GetConnectionString("RedisConnection");
                options.InstanceName = "RaphaelRedisTest";
            });


            //Dependency Injection
            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddTransient(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));

            services.AddTransient<IRepositoryBaseRedis, RepositoryBaseRedis>();
            services.AddTransient(typeof(IServiceBaseRedis<>), typeof(ServiceBaseRedis<>));
            services.AddTransient(typeof(IAppServiceBaseRedis<>), typeof(AppServiceBaseRedis<>));

            
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IPersonAppService, PersonAppService>();

            services.AddTransient<IPersonAppServiceRedis, PersonAppServiceRedis>();
            services.AddTransient<IPersonServiceRedis, PersonServiceRedis>();
            services.AddTransient<IPersonRepositoryRedis, PersonRepositoryRedis>();

            services.AddTransient<IReflectionService, ReflectionService>();

            services.AddTransient<IValidator<Models.Person>, PersonValidator>();

            //Added option to accept XML. Json is accepted by default.
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()))
                .AddFluentValidation();

            var connectionString = Configuration["connectionStrings:personDbConnectionString"];
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<CrudApiContext>(
                    options => options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            loggerFactory.AddNLog();
            //If to show an exception page on development environment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseMvc();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Domain.Entities.Person, Models.Person>();
            });
        }
    }
}
