using System.ComponentModel.DataAnnotations;

namespace FormApp.API.Dtos
{
    public class UserDlaRejestracjiDto
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana!!!")]
        public string Username { get; set; }
        
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Podaj prawidlowe haslo od 4 do 8 znakow!!!")]
        public string Password { get; set; }
    }
}