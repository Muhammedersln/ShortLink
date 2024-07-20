using ShortLink.Client.Helpers.Validators;
using System.ComponentModel.DataAnnotations;

namespace ShortLink.Client.Data.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Eposta adresi gerekli")]
        [CustomEmailValidator(ErrorMessage = "E-posta adresi geçerli değil (custom)")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Şifre  gerekli")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır")]
        public string Password { get; set; }
    }
}
