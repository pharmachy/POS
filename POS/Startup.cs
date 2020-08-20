using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using AutoMapper;
using POS.Infrastructure;
using POS.Repository;


namespace POS
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<POSDbContext>(options =>
                options.UseSqlServer(
              Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<POSDbContext>();
            services.AddTransient<ICategory, CategoryRepo>();           
            services.AddTransient<ICustomer, CustomerRepo>();
            services.AddTransient<ISubCategory, SubCategoryRepo>();
            services.AddTransient<IPurchase, PurchaseRepo>();
            services.AddTransient<IDepartmentRepo, DepartmentService>();
            services.AddTransient<ISupplier, SupplierRepo>();
            services.AddScoped<ICompany, CompanyService>();
            services.AddScoped<IProduct, ProductService>();
            services.AddScoped<ISale, SaleRepo>();
            services.AddScoped<IBrand, BrandRepo>();
            services.AddScoped<IUnit, UnitService>();       
            services.AddScoped<IBrandModel, BrandModelRepo>();       
           
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            UpdateDatabase(app);
        }


        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
              .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<POSDbContext>())
                {
                    context.Database.Migrate();
                    Seed.Initialize(serviceScope.ServiceProvider);
                }
            }
        }
    }
}
