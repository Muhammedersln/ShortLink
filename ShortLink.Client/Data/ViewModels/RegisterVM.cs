using System.ComponentModel.DataAnnotations;

namespace ShortLink.Client.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Ad Soyad gereklidir")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "E-posta adresi gereklidir")]
        [RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage = "Geçersiz e-posta adresi")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir")]
        [MinLength(5, ErrorMessage = "Şifre en az 5 karakter olmalıdır")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı gereklidir")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
        public string ConfirmPassword { get; set; }
    }

}
