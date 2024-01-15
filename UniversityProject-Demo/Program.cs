using Microsoft.EntityFrameworkCore;
using UniversityProject_Demo.Database;
using UniversityProject_Demo.Database.ModelRepository;
using UniversityProject_Demo.Models.Entity;

namespace UniversityProject_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            /*            builder.Services.AddDbContext<UniversityContext>(options => options.UseSqlServer(
                        builder.Configuration.GetConnectionString("UniversityCoreDb")));*/
            builder.Services.AddSingleton<IRepository<Course>, CoursesRepository>();
            builder.Services.AddSingleton<IRepository<Student>, StudentRepository>();
            builder.Services.AddSingleton<IRepository<Lecturer>, LecturerRepository>();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}