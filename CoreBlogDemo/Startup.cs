using DataAccessLayer.Concrate;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogDemo
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
           
           

            services.AddControllersWithViews(); //.AddRazorRuntimeCompilation()


            services.AddRazorPages().AddRazorRuntimeCompilation(); //Add this line of code


            services.AddSession();


            services.AddDbContext<Context>();
            //services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(@"Data Source= DESKTOP-G2007Q5;Initial Catalog=CoreBlogDemoDB;Integrated Security=true"));

            services.AddIdentity<AppUser, AppRole>(x =>
            {
                //�ifrede=>

                x.Password.RequireUppercase = false; /* => B�y�k harf mecburiyrti olmas�n*/
                x.Password.RequireNonAlphanumeric = false; /* => Numara mecburiyrti olmas�n*/
            })

                .AddEntityFrameworkStores<Context>();



            //proje seviyesinde Authorize i�lemleri yani bu projedeki sayfalara eri�im yapabilmek i�in login olman gerek
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });



            services.AddMvc();
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";
                }
             );



            services.ConfigureApplicationCookie(options =>
            {
                //Cookie settins
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(100);//100dk otantike olunacak
                options.AccessDeniedPath = new PathString("/Login/AccessDenied/");  //giri� engeli oldu�u zaman y�nlendirme
                options.LoginPath = "/Login/Index";
                options.SlidingExpiration = true;
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Farkl� bir eror sayfas�na y�nlendirmrk i�in
            // app.UseStatusCodePages();//Kullan�mDurumKoduSayfalar�


            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UseSession();   

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");//=>Areas'� ekleme kodu



                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
