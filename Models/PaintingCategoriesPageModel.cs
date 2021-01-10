using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProiectMedii.Models;
using ProiectMedii.Data;

//Metoda PopulateAssignedCategoryData citeste entitatile Category si populeaza lista AssignedCategoryDataList. 

namespace ProiectMedii.Models
{
    public class PaintingCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(ProiectMediiContext context,Painting painting)
        {
            var allCategories = context.Category;
            var paintingCategories = new HashSet<int>(
            painting.PaintingCategories.Select(c => c.CategoryID)); //greseala ? PaintingID - CategoryID 
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = paintingCategories.Contains(cat.ID)
                });
            }


        }
        public void UpdatePaintingCategories(ProiectMediiContext context, string[] selectedCategories, Painting paintingToUpdate)
        {
            if (selectedCategories == null)
            {
                paintingToUpdate.PaintingCategories = new List<PaintingCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var paintingCategories = new HashSet<int>
            (paintingToUpdate.PaintingCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!paintingCategories.Contains(cat.ID))
                    {
                        paintingToUpdate.PaintingCategories.Add(
                        new PaintingCategory
                        {
                            PaintingID = paintingToUpdate.ID,
                            CategoryID = cat.ID
                         
                        });
                    }
                }
                else
                {
                    if (paintingCategories.Contains(cat.ID))
                    {
                        PaintingCategory courseToRemove
                        = paintingToUpdate
                        .PaintingCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }


    }
}
