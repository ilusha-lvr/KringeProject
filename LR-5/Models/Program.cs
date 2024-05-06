using LR_5.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string con = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<PostgresContext>(option => option.UseNpgsql(con));

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(); // ��������� ��������� �������������� �� ����

        builder.Services.AddControllersWithViews();
        builder.Services.AddSession(); // ��������� ��������� ������

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication(); // ��������� ������������� ��������������
        app.UseAuthorization();

        app.UseSession(); // ���������� ������

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}