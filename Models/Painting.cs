using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectMedii.Models
{
    public class Painting
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name="Painting name")]
        public string Name { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele artistului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)]

        public string Artist { get; set; }
        [Column(TypeName ="decimal(6,2)")]
        [Range(1, 50000)]

        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExhibitionDate { get; set; }
        public int ExhibitionID { get; set; }
        public Exhibition Exhibition { get; set; }
        public ICollection<PaintingCategory> PaintingCategories { get; set; }
    }
}
