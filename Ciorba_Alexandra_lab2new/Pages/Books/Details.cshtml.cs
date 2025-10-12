using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciorba_Alexandra_lab2new.Data;
using Ciorba_Alexandra_lab2new.Models;

namespace Ciorba_Alexandra_lab2new.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Ciorba_Alexandra_lab2new.Data.Ciorba_Alexandra_lab2newContext _context;

        public DetailsModel(Ciorba_Alexandra_lab2new.Data.Ciorba_Alexandra_lab2newContext context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                 .Include(b =>b.Author)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }
    }
}
