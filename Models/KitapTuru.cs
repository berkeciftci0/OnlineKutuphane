using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebUygulamaProje1.Models
{
    public class KitapTuru
    {
        [Key] //primary key
        public int Id { get; set; }
        [Required(ErrorMessage ="Kitap Türü Adı Boş Bırakılamaz!!!")] //not null
        [MaxLength(25)] //max 25 karakter girilebilir
        [DisplayName("Kitap Türü Adı")] //Ekranda Böyle gözükmesi için 
        public required string Ad { get; set; }  
    }
}
