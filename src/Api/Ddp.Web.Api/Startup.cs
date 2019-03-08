using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Ddp.Application.Autofac;
using Ddp.Data.Ef;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ddp.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<DdpContext>(options =>
                    options.UseSqlServer("database=localhost; initial catalog=ddp; user=ddp=password=ddp", sqlServerOptionsAction => sqlServerOptionsAction.MigrationsAssembly(typeof(DdpContext).Assembly.FullName)));

            var builder = new ContainerBuilder();

            builder.Populate(services);
            builder.RegisterModule<DdpApplicationAutofacModule>();
            builder.RegisterType<DdpContextProvider>().As<IDdpContextProvider>().InstancePerLifetimeScope();
            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseStaticFiles();
            
        }
    }
}
