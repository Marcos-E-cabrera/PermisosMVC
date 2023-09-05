using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProyectoRol.Models.DB;
using ProyectoRol.Models.Services;

namespace ProyectoRol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MiSistema02Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MiSistema02"));
            });

            builder.Services.AddScoped<IAcceso,Acceso>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Acceso/Index";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
                options.AccessDeniedPath = "/home/Privacy";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Acceso}/{action=Index}/{id?}");

            app.Run();
        }
    }
}