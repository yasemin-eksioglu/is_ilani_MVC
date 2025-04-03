using is_ilani_MVC.Identity;
using is_ilani_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace is_ilani_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Musteri> _userManager;
        private readonly SignInManager<Musteri> _signInManager;

        public AccountController(UserManager<Musteri> userManager, SignInManager<Musteri> signInManager)
        {
            userManager = _userManager;
            signInManager=_signInManager;
        }

        public IActionResult Login()
        {
            return View(new GirisYap());
        }

        [HttpPost]
        public async Task<IActionResult> Login(GirisYap model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var result=await _signInManager.PasswordSignInAsync(user, model.Password,false,true); //false:beni hatırlama,true:5 kere yanlış girince kitleme olsun mu özelliği etkin
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); //giriş başarılı olursa index'e git
                }
            }
            return View(model);
        }

        [HttpGet] //Attribute verilmeyen her metot HttpGet olarak tanımlanır.Get sayfa çağırmayı sağlar
        public IActionResult Register()
        {
            return View(new KayitOl());
        }

        [HttpPost] //Şifreyi gizlemek için datayı post ile taşıyoruz
        public async Task<IActionResult> Register(KayitOl model)
        {
            //if (model.Password.Length<6)
            //{
            //    ModelState.AddModelError("", "Şifreniz En Az 6 Karakterli Olmalıdır.");
            //    return View(model);
            //}
            if (ModelState.IsValid)
            {
                Musteri musteri = new Musteri();
                musteri.Email= model.Email;
                musteri.PhoneNumber = model.TelNo;
                musteri.FullName=model.adSoyad;

                var result = await _userManager.CreateAsync(musteri, model.Password);

                if (result.Errors.Count()>0)
                {
                    foreach (var i in result.Errors)
                    {
                        ModelState.AddModelError(i.Code, i.Description); 
                    }
                    return View(model);
                    
                }
                
                return RedirectToAction("Login");


            }
            return View(model); //if e giremezse gelen modeli geri götürecek
        }
    }
}
