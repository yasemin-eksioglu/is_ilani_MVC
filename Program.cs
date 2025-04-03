using is_ilani_MVC.Identity;
using is_ilani_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace is_ilani_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //Veritaban� ba�lant� i�lemini yapm�� olduk

            builder.Services.AddIdentity<Musteri, IdentityRole>() //IdentityRole ile bir rol verdik ve devam�nda rolleri kullan�c� ile e�le�tiriyoruz; 
                .AddEntityFrameworkStores<DataContext>() //Yay�na ��kar
                .AddDefaultTokenProviders(); //Bir anahtar �zerinden ba�lant� yap

            builder.Services.Configure<IdentityOptions>(options =>
            {
                //�ifre
                options.Password.RequireDigit = true;  //rakam zorunlu
                options.Password.RequireLowercase = true; //k���k harf zorunlu
                options.Password.RequireUppercase = true; //b�y�k harf zorunlu
                options.Password.RequireNonAlphanumeric = true; //�zel karakter zorunlu
                options.Password.RequiredLength = 6; // en az 6 karakter


                //hatal� giri�
                options.Lockout.MaxFailedAccessAttempts = 5; //max hatal� giri�
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);//5 hatal� giri�ten sonra 5 dk sistemi kitle
                options.Lockout.AllowedForNewUsers = true;//Her yeni kay�t i�in uygula 


                //kullan�c�
                options.User.RequireUniqueEmail = true;//e mail adresi benzersiz olmal�

                //Giri�
                options.SignIn.RequireConfirmedEmail = false;//giri� i�in emaili onayl� olmas�n
                options.SignIn.RequireConfirmedPhoneNumber = false;//Giri� i�in tel no onayl� olmas�n
            });

            //Configure Cookie
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login"; //Giri� gerektiren bi sayfa olursa
                options.LogoutPath = "/Account/Logout"; //��k�� yapmak isterse 
                options.AccessDeniedPath = "/Account/AccessDenied"; //yetkisi olmayan bi sayfaya gitmeye �al���rsa
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //Hi�bi �ey yapmazsa oturum s�resi(dakika)
                options.SlidingExpiration = true;//Herhangi bi �eye t�klarsa s�re yeniden ba�las�n
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = "is_ilani_MVC.Security.Cookie",
                    SameSite = SameSiteMode.Strict //Oturumu kullan�c�n�n browser� tutsun yani b�t�n y�k onun taray�c�s�nda 
                };
            });


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
