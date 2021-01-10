using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMedii.Models
{
    public class PaintingData
    {
        public IEnumerable<Painting> Paintings { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<PaintingCategory> PaintingCategories { get; set; }
    }
}
