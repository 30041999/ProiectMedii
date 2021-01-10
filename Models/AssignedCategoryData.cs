using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Models
{
    public class AssignedCategoryData
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }

    }
}
