using BlogSample.BLL.Abstract;
using BlogSample.BLL.BlogService;
using BlogSample.Core.Data.UnitOfWork;
using BlogSample.DAL;
using BlogSample.Mapping.ConfigProfile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "CategoryList",
                    pattern: "Admin/Categories",
                    defaults: new {controller = "Admin", Action = "CategoryList"});
                endpoints.MapControllerRoute(
                    name: "UserList",
                    pattern: "Admin/Users",
                    defaults: new { controller = "Admin", Action = "UserList" });
                endpoints.MapControllerRoute(
                    name: "UserAdd",
                    pattern: "Admin/UserAdd",
                    defaults: new { controller = "Admin", Action = "UserAdd" });

                endpoints.MapControllerRoute(
                    name: "RoleList",
                    pattern: "Admin/Roles",
                    defaults: new { controller = "Admin", Action = "RoleList" });
                endpoints.MapControllerRoute(
                    name: "RoleAdd",
                    pattern: "Admin/RoleAdd",
                    defaults: new { controller = "Admin", Action = "RoleAdd" });

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
