using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace UI_MVC.Core
{
    /*here where we apply the required plumbing.*/
    public class Startup
    {
        /*** ASP.Net Core calls this constructor on application startup ***/
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        //public IConfiguration Configuration { get; }



        // This method gets called by the runtime and only runs once. Use this method to add services to the container.
        /* By convention, ASP.Net calls this method.
         * The supplied IServiceCollection instance lets you influence the default services that ASP.NET knows about.
         */
        public void ConfigureServices(IServiceCollection services)
        {
            //ce que j'ai ajouté à la version brute---------------------------------------------------------------------
            /*Adds a service to the framework, which retrieves the current HttpContext*/
            services.AddHttpContextAccessor();
            /*Replaces the default IControllerActivator with one that builds the object graphs*/
            services.AddSingleton<IControllerActivator>(new CustomControllerActivator("Data Source=localhost\\ADINAMEDINSTANCE; Database=Steven&Mark_DI; Integrated Security=true; Connection Timeout=5"));
            //----------------------------------------------------------------------------------------------------------
            services.AddControllersWithViews();

            /*if we use configuration file*/
            //var connectionString = Configuration.GetConnectionString("CommerceConnection");
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            //app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }






}
