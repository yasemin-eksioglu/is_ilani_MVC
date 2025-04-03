using System.ComponentModel.DataAnnotations;

namespace is_ilani_MVC.Models
{
    public class GirisYap
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
