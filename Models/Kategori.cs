namespace is_ilani_MVC.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string ad { get; set; }

        public List<Ilanlar> ilanlar { get; set; }
    }
}
