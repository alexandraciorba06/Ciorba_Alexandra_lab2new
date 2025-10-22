using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciorba_Alexandra_lab2new.Data;
using Ciorba_Alexandra_lab2new.Models;
using Ciorba_Alexandra_lab2new.Models.ViewModels;

namespace Ciorba_Alexandra_lab2new.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Ciorba_Alexandra_lab2new.Data.Ciorba_Alexandra_lab2newContext _context;

        public IndexModel(Ciorba_Alexandra_lab2new.Data.Ciorba_Alexandra_lab2newContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;
        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(c => c.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(c => c.ID == id.Value)
                    .Single();
                CategoryData.Books = category.BookCategories
                    .Select(bc => bc.Book);
            }
        }
    }
}
