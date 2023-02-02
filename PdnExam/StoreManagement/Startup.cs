using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StoreManagement
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

            string connectionString = Configuration.GetConnectionString("default");
            services.AddDbContext<StoreDbContext>(c => 
                c.UseSqlServer(connectionString)
            );

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<StoreDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, StoreDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            db.Database.Migrate();

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Products}/{action=Index}");

                routes.MapRoute(
                    name: "addProduct",
                    template: "{controller=Products}/{action=Add}");

                routes.MapRoute(
                    name: "editProduct",
                    template: "{controller=Products}/{action=Edit}/{id}");

                routes.MapRoute(
                    name: "invoices",
                    template: "{controller=Invoices}/{action=Index}");

                routes.MapRoute(
                    name: "addInvoice",
                    template: "{controller=Invoices}/{action=Add}");

                routes.MapRoute(
                    name: "editInvoice",
                    template: "{controller=Invoices}/{action=Edit}/{id}");
            });
        }
    }
}
