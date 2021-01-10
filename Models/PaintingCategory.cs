using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMedii.Models;

namespace ProiectMedii.Models
{
    public class PaintingCategory
    {
        public int ID { get; set; }
        public int PaintingID { get; set; }
        public Painting Painting { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
