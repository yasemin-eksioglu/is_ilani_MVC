namespace is_ilani_MVC.Models
{
    public class Isveren
    {
        public int Id { get; set; }
        public string sirketAdi { get; set; }
        public string sektor { get; set; }
        public string adres { get; set; }
        public int kurulusYili { get; set; }
        public int calisanSayisi { get; set; }

        public int kullaniciId { get; set; }
        public Kullanici kullanici { get; set; }

        public List<Ilanlar> ilanlar { get; set; }


    }
}
