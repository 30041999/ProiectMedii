using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Paintings
{
    public class CreateModel : PaintingCategoriesPageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public CreateModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ExhibitionID"] = new SelectList(_context.Set<Exhibition>(), "ID", "ExhibitionName");
            var painting = new Painting();
            painting.PaintingCategories = new List<PaintingCategory>();
            PopulateAssignedCategoryData(_context, painting);
            return Page();
        }

        [BindProperty]
        public Painting Painting { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newPainting = new Painting();
            if (selectedCategories != null)
            {
                newPainting.PaintingCategories = new List<PaintingCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new PaintingCategory
                    {
                        CategoryID = int.Parse(cat)
                      
                    };
                    newPainting.PaintingCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Painting>(
            newPainting,
            "Painting",
            i => i.Name, i => i.Artist,
            i => i.Price, i => i.ExhibitionDate, i => i.ExhibitionID))
            {
                _context.Painting.Add(newPainting);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newPainting);
            return Page();
        }
    }
}
