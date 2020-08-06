using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Models;

namespace SportsStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, FakeProductRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseDeveloperExceptionPage(); //Вывод информации об исключениях
            app.UseStatusCodePages(); //Вывод обработки ошибок HTTP
            app.UseStaticFiles();  //Для папки wwwroot
            app.UseMvc(routes => {
                 routes.MapRoute(name: "default", template: "{controller=Product}/{action=List}/{id?}");
            });  //Включение инфраструктуры APS.NET Core MVC

        }
    }
}
