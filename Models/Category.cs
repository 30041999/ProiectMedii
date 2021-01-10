using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMedii.Models;
using ProiectMedii.Data;

namespace ProiectMedii.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<PaintingCategory> PaintingCategories { get; set; }


    }
}
