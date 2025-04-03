using is_ilani_MVC.Identity;
using Microsoft.AspNetCore.Identity;

namespace is_ilani_MVC.Models
{
    public enum kullaniciRolu
    {
        Aday,
        Isveren
    }
    public class Kullanici
    {
        public int Id { get; set; }
        public kullaniciRolu rol { get; set; }

        public string MusteriId { get; set; }
        public Musteri Musteri { get; set; }

        public List<Basvuru> basvurular { get; set; } // Adayın yaptığı başvurular
        public List<Ilanlar> ilanlar { get; set; } // İşverenin açtığı ilanlar

    }
}
