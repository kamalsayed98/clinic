using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinic8.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic8
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();
           
            //services.ConfigureApplicationCookie(options => options.Cookie.IsEssential = true);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
           /* services.AddMvc().AddRazorPagesOptions(options =>
            {
                 options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
                *//*options.Conventions.AuthorizePage("/Home");
                options.Conventions.AllowAnonymousToPage("/Home");*//*
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env
            , ApplicationDbContext context, RoleManager<IdentityRole> roleManager
            , UserManager<IdentityUser> userManager)
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
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "Admin",
                   template: "/Admin",
              defaults: new { controller = "Admins", action = "Main" });

                routes.MapRoute(
                   name: "Doctor",
                   template: "/Doctor",
                   defaults: new { controller = "Doctors", action = "ViewDates" });

                routes.MapRoute(
                        name: "Patient",
                     template: "/Patient",
                     defaults: new { controller = "Patients", action = "ViewDates" });

                routes.MapRoute(
                  name: "Assistant",
                  template: "/Assistant",
                 defaults: new { controller = "Patients", action = "Index" });

                routes.MapRoute(
              name: "Insurance",
              template: "/Insurance",
             defaults: new { controller = "InsuranceCompanies", action = "Main" });

                 routes.MapRoute(
              name: "Index1",
              template: "/Home",
             defaults: new { controller = "Home", action = "Index1" });

               

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            DummyData.Initialize(context, userManager, roleManager).Wait();
        }
    }
}
