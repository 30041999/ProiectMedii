using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Paintings
{
    public class IndexModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public IndexModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IList<Painting> Painting { get;set; }
        public PaintingData PaintingD { get; set; }
        public int PaintingID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            PaintingD = new PaintingData();

            PaintingD.Paintings = await _context.Painting
            //.Include(b => b.ExhibitionDate)
            .Include(b => b.Exhibition)
            .Include(b => b.PaintingCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                PaintingID = id.Value;
                Painting painting = PaintingD.Paintings
                .Where(i => i.ID == id.Value).Single();
                PaintingD.Categories = painting.PaintingCategories.Select(s => s.Category);
            }
        }

    }
}
