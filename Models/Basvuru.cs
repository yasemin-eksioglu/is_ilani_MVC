namespace is_ilani_MVC.Models
{
    public class Basvuru
    {
        public int Id { get; set; }
        public string onYazi { get; set; }
        public DateTime basvuruTarihi { get; set; } = DateTime.Now;

        public Kullanici aday { get; set; }

        public int ilanId { get; set; }
        public Ilanlar ilan { get; set; }


    }
}
