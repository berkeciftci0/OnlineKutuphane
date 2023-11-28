using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUygulamaProje1.Models
{
    public class Kitap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string KitapAdi { get; set; }

        public required string Tanim { get; set; }

        [Required]
        public required string Yazar { get; set; }

        [Required]
        [Range(10, 5000)]
        public double Fiyat { get; set; }

        [ValidateNever]
        public int KitapTuruId { get; set; }

        [ForeignKey("KitapTuruId")]
        [ValidateNever]
        public required KitapTuru kitapTuru { get; set; }

        [ValidateNever]
        public required string ResimUrl { get; set; }

    }
}
