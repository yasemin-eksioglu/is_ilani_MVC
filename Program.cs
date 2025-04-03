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
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //Veritabaný baðlantý iþlemini yapmýþ olduk

            builder.Services.AddIdentity<Musteri, IdentityRole>() //IdentityRole ile bir rol verdik ve devamýnda rolleri kullanýcý ile eþleþtiriyoruz; 
                .AddEntityFrameworkStores<DataContext>() //Yayýna çýkar
                .AddDefaultTokenProviders(); //Bir anahtar üzerinden baðlantý yap

            builder.Services.Configure<IdentityOptions>(options =>
            {
                //þifre
                options.Password.RequireDigit = true;  //rakam zorunlu
                options.Password.RequireLowercase = true; //küçük harf zorunlu
                options.Password.RequireUppercase = true; //büyük harf zorunlu
                options.Password.RequireNonAlphanumeric = true; //özel karakter zorunlu
                options.Password.RequiredLength = 6; // en az 6 karakter


                //hatalý giriþ
                options.Lockout.MaxFailedAccessAttempts = 5; //max hatalý giriþ
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);//5 hatalý giriþten sonra 5 dk sistemi kitle
                options.Lockout.AllowedForNewUsers = true;//Her yeni kayýt için uygula 


                //kullanýcý
                options.User.RequireUniqueEmail = true;//e mail adresi benzersiz olmalý

                //Giriþ
                options.SignIn.RequireConfirmedEmail = false;//giriþ için emaili onaylý olmasýn
                options.SignIn.RequireConfirmedPhoneNumber = false;//Giriþ için tel no onaylý olmasýn
            });

            //Configure Cookie
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login"; //Giriþ gerektiren bi sayfa olursa
                options.LogoutPath = "/Account/Logout"; //Çýkýþ yapmak isterse 
                options.AccessDeniedPath = "/Account/AccessDenied"; //yetkisi olmayan bi sayfaya gitmeye çalýþýrsa
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //Hiçbi þey yapmazsa oturum süresi(dakika)
                options.SlidingExpiration = true;//Herhangi bi þeye týklarsa süre yeniden baþlasýn
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = "is_ilani_MVC.Security.Cookie",
                    SameSite = SameSiteMode.Strict //Oturumu kullanýcýnýn browserý tutsun yani bütün yük onun tarayýcýsýnda 
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
