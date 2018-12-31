using GolfPracticeTracker.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace GolfPracticeTracker
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
            // For now, I'll just use the index page and default routing to show the dashboard.  To change the default landing page:
            // In the AddRazorPagesOptions() method, we can set things like route conventions and the root directory for pages.
            // It turns out that, to set a default route for a page, you execute this call:
            //  public void ConfigureServices(IServiceCollection services)
            //  {
            //      services.AddMvc().AddRazorPagesOptions(options =>
            //      {
            //      options.Conventions.AddPageRoute("/Employees/Index", "");
            //      });
            //  }   
            //  Note the parameters for the AddPageRoute() method.The first parameter takes the path to the page for which we want 
            //  to add a route.The second identifies the route that should map to the page.In my case, since I wanted the default page 
            //  for the entire app to be the /Pages/Employees/Index.cshtml page, I pass in an empty string. And, voila, the page now maps correctly:


            services.AddDbContext<GolfPracticeTrackerContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("GolfPracticeTrackerContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}