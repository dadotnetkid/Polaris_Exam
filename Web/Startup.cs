using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Syncfusion.Licensing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FluentValidation.AspNetCore;
using Services.DI;
using Web.Data;
using Microsoft.AspNetCore.Session;
namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            SyncfusionLicenseProvider.RegisterLicense("MDAxQDMxMzgyZTM0MmUzMGdVTXdwditJbDRRYjQ0QXpRL2xXOTFpZk0zcWxVeTUySW5Fc0g4MDlQbWM9");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //Autofac container
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            //Add Fluent Validation
            services.AddMvc().AddFluentValidation(options =>
            {
                /*options.RegisterValidatorsFromAssemblyContaining<SalesOrderValidator>();
                options.RegisterValidatorsFromAssemblyContaining<SalesOrderValidator>();*/
                // /**/options.RegisterValidatorsFromAssemblyContaining<AutofacService>();/**/
                options.RegisterValidatorsFromAssemblyContaining<AutofacModules>();
                options.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });

        }
        //Autofac Container
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModules());
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
