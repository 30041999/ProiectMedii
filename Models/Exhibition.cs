using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProiectMedii.Models
{
    public class Exhibition
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        public string ExhibitionName { get; set; }
        public ICollection<Painting> Paintings { get; set; }
    }
}
