using is_ilani_MVC.Models;
using Microsoft.AspNetCore.Identity;

namespace is_ilani_MVC.Identity
{
    public class Musteri:IdentityUser
    {
        public string FullName { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}
