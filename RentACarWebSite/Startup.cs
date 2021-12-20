using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RentACarWebSite.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace RentACarWebSite
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
            services.AddControllers()
        .AddNewtonsoftJson(options =>
         {
              options.SerializerSettings.ContractResolver = new DefaultContractResolver();
         });



            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(

                opt =>
                {
                    var supportedCulteres = new List<CultureInfo>
                    {
                        new CultureInfo("en"),
                        new CultureInfo("tr")
                    };
                    opt.DefaultRequestCulture = new RequestCulture("en");
                    opt.SupportedUICultures = supportedCulteres;
                });
            services.AddControllersWithViews();
            var connection = @"server=.;database=RentACar;trusted_connection=true;";
            object p = services.AddDbContext<RentACarContext>(obtions => obtions.UseSqlServer(connection));

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Account/SignInMembers";
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);


            //var supportedCultres = new[] { "en", "tr" };
            //var locatizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultres[0])
            //    .AddSupportedCultures(supportedCultres)
            //    .AddSupportedUICultures(supportedCultres);
            //app.UseRequestLocalization(locatizationOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Cars}/{action=CarsListNotSignIn}/{id?}");
            });
        }
    }
}
