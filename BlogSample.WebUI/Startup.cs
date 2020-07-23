using BlogSample.BLL.Abstract;
using BlogSample.BLL.BlogService;
using BlogSample.Core.Data.UnitOfWork;
using BlogSample.DAL;
using BlogSample.Mapping.ConfigProfile;
using BlogSample.WebUI.CustomHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace BlogSample.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            MapperConfig.RegisterMappers();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            // Dependency Ýnjection
            services.AddControllersWithViews();
            services.AddSingleton<ICategoryService,CategoryService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IRoleService, RoleService>();
            services.AddSingleton<IUnitofWork, UnitofWork>();
            services.AddSingleton<IArticleService, ArticleService>();
            // DbContext yarlarý
            var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("BlogDbConnection"));
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.EnableSensitiveDataLogging();

            services.AddSingleton<DbContext>(new BlogDbContext(optionsBuilder.Options));
            using (var context = new BlogDbContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
                context.Database.Migrate();
            }

            //Login Ayarlarý
            services.AddScoped<IAuthorizationHandler, PoliciesAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();

            services.AddAuthentication("CookieAuthentication")
                 .AddCookie("CookieAuthentication", config =>
                 {
                     config.Cookie.Name = "UserLoginCookie";
                     config.LoginPath = "/Login";
                     config.AccessDeniedPath = "/AccessDenied";
                 });

            services.AddAuthorization(config =>
            {
                config.AddPolicy("UserPolicy", policyBuilder =>
                {
                    policyBuilder.UserRequireCustomClaim(ClaimTypes.Email);
                });
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "Register",
                   pattern: "Register",
                   defaults: new { controller = "Login", action = "Register" });

                endpoints.MapControllerRoute(
                    name: "Login",
                    pattern: "Login",
                    defaults: new { controller = "Login", action = "UserLogin" });

                endpoints.MapControllerRoute(
                     name: "AccessDenied",
                     pattern: "AccessDenied",
                     defaults: new { controller = "Login", action = "AccessDenied" });

                endpoints.MapControllerRoute(
                     name: "Logout",
                     pattern: "Logout",
                     defaults: new { controller = "Login", action = "Logout" });



                endpoints.MapControllerRoute(
                         name: "CategoryList",
                          pattern: "Admin/Categories",
                           defaults: new { controller = "Admin", action = "CategoryList" });
                endpoints.MapControllerRoute(
                      name: "UserList",
                      pattern: "Admin/Users",
                      defaults: new { controller = "Admin", action = "UserList" });


                endpoints.MapControllerRoute(
                      name: "UserAdd",
                      pattern: "Admin/UserAdd",
                      defaults: new { controller = "Admin", action = "UserAdd" });

                endpoints.MapControllerRoute(
                     name: "RoleList",
                     pattern: "Admin/Roles",
                     defaults: new { controller = "Admin", action = "RoleList" });
                endpoints.MapControllerRoute(
                      name: "RoleAdd",
                      pattern: "Admin/RoleAdd",
                      defaults: new { controller = "Admin", action = "RoleAdd" });

                endpoints.MapControllerRoute(
                    name: "ArticleList",
                    pattern: "Admin/Articles",
                    defaults: new { controller = "Admin", Action = "ArticleList" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
