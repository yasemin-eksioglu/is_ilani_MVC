using System.ComponentModel.DataAnnotations;

namespace is_ilani_MVC.Models
{
    public class Aday
    {
        public int Id { get; set; }
        public string ad { get; set; }
        public string cv { get; set; }
        public string TelNo { get; set; }
        public int kullaniciId { get; set; }
        public Kullanici kullanici { get; set; }

        public List<Basvuru> basvurular { get; set; }

    }
}
