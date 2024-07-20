using System.ComponentModel.DataAnnotations;

namespace ShortLink.Client.Data.ViewModels
{
    public class PostUrlVM
    {
        [Required(ErrorMessage = "Url gerekli")]
        [RegularExpression("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$", ErrorMessage = "Geçerli Url girin")]
        public string? Url { get; set; }
    }
}
