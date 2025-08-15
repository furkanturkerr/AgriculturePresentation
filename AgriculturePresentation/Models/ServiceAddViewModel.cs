using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models;

public class ServiceAddViewModel
{
    [Display(Name = "Başlık")]
    [Required(ErrorMessage = "Başlık Boş Geçilemez")]
    public string Title { get; set; }
    
    [Display(Name = "Görsel")]
    [Required(ErrorMessage = "Görsel Değeri Boş Geçilemez")]
    public string Image { get; set; }
    
    [Display(Name = "Açıklama")]
    [Required(ErrorMessage = "Açıklalama Boş Geçilemez")]
    public string Description { get; set; }
}