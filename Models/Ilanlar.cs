namespace is_ilani_MVC.Models
{
    public class Ilanlar
    {
        public int Id { get; set; }
        public string pozisyon { get; set; }
        public string departman { get; set; }
        public string genelNitelikler { get; set; }
        public string isTanimi { get; set; }


        public int kategoriId { get; set; }
        public Kategori kategori { get; set; }

        public int isverenId { get; set; }
        public Kullanici isveren { get; set; }

        public bool IsActive { get; set; } = true; //ilan aktif mi?

    }
}
