using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaymentCenter.BusinessLayer.Abstract;
using PaymentCenter.BusinessLayer.Concrete;
using PaymentCenter.DataAccessLayer.Abstract;
using PaymentCenter.DataAccessLayer.Concrete;
using PaymentCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentCenter.WebAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddTransient<IRepository<BoxOfficeAttendant>, MsSqlRepository<BoxOfficeAttendant>>();
            services.AddTransient<IRepository<Institution>, MsSqlRepository<Institution>>();
            services.AddTransient<IRepository<InstitutionSubscriber>, MsSqlRepository<InstitutionSubscriber>>();
            services.AddTransient<IRepository<InstitutionType>, MsSqlRepository<InstitutionType>>();
            services.AddTransient<IRepository<Invoice>, MsSqlRepository<Invoice>>();
            services.AddTransient<IRepository<Subscriber>, MsSqlRepository<Subscriber>>();

            services.AddTransient<IService<BoxOfficeAttendant>, BoxOfficeAttendantManager>();
            services.AddTransient<IService<Institution>, InstitutionManager>();
            services.AddTransient<IService<InstitutionSubscriber>, InstitutionSubscriberManager>();
            services.AddTransient<IService<InstitutionType>, InstitutionTypeManager>();
            services.AddTransient<IService<Invoice>, InvoiceManager>();
            services.AddTransient<IService<Subscriber>, SubscriberManager>();

            services.AddTransient<ISubscriberService<Subscriber>, SubscriberManager>();
            services.AddTransient<IInstitutionSubscriberService<InstitutionSubscriber>, InstitutionSubscriberManager>();

            services.AddSwaggerDocument(config => config.PostProcess = (doc =>
            {
                doc.Info.Title = "Payment Center Api";
                doc.Info.Version = "1.1.1";
                doc.Info.Contact = new NSwag.OpenApiContact()
                {
                    Name = "Fýrat Kaya.",
                    Url = "http://youtube.com",
                    Email = ""
                };
            }));
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

            app.UseRouting();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
