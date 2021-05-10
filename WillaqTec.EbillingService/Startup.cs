using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillaqTec.EbillingService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IIdentityDocumentTypeRepository, IdentityDocumentTypeRepository>();
            services.AddScoped<IIdentityDocumentTypeService, IdentityDocumentTypeService>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyCreditCardRepository, CompanyCreditCardRepository>();
            services.AddScoped<ICompanyCreditCardService, CompanyCreditCardService>();
            services.AddScoped<IPaymentPlanRepository, PaymentPlanRepository>();
            services.AddScoped<IPaymentPlanService, PaymentPlanService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentOperationRepository, PaymentOperationRepository>();
            services.AddScoped<IPaymentOperationService, PaymentOperationService>();

            services.AddScoped<ISecurityCommandText, SecurityCommandText>();
            services.AddScoped<IMainCommandText, MainCommandText>();
            services.AddScoped<IPaymentCommandText, PaymentCommandText>();
            services.AddMvc();
            services.AddSession();
            services.AddAuthentication("CookieAuthentication").AddCookie("CookieAuthentication", config =>
            {
                config.Cookie.Name = "UserLoginCookie";
                config.LoginPath = "/Login/Index";
            });
            services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            //app.UseMvc();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
