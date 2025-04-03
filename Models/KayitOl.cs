using System.ComponentModel.DataAnnotations;

namespace is_ilani_MVC.Models
{
    public class KayitOl
    {
        [Required(ErrorMessage ="İsim Soyisim Kısmı Boş Bırakılamaz!")]
        public string adSoyad { get; set; }

        [Required(ErrorMessage = "Şifre Kısmı Boş Bırakılamaz!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifreler Eşleşmiyor!")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
        [Required(ErrorMessage = "Email Kısmı Boş Bırakılamaz!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string? TelNo { get; set; }

    }
}
