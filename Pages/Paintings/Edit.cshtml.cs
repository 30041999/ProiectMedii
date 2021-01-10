using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Paintings
{
    public class EditModel : PaintingCategoriesPageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public EditModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Painting Painting { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Painting = await _context.Painting
                .Include(b => b.Exhibition)
                .Include(b => b.PaintingCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Painting == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Painting);
            ViewData["ExhibitionID"] = new SelectList(_context.Set<Exhibition>(), "ID", "ExhibitionName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id,string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var paintingToUpdate = await _context.Painting
            .Include(i => i.Exhibition)
            .Include(i => i.PaintingCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (paintingToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Painting>(
            paintingToUpdate,
            "Painting",
            i => i.Name, i => i.Artist,
            i => i.Price, i => i.ExhibitionDate, i => i.Exhibition))
            {
                UpdatePaintingCategories(_context, selectedCategories, paintingToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdatePaintingCategories(_context, selectedCategories, paintingToUpdate);
            PopulateAssignedCategoryData(_context, paintingToUpdate);
            return Page();
        }

    }
    
}
