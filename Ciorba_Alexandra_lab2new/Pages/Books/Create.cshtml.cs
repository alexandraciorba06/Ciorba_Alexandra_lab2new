using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ciorba_Alexandra_lab2new.Data;
using Ciorba_Alexandra_lab2new.Models;

namespace Ciorba_Alexandra_lab2new.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Ciorba_Alexandra_lab2new.Data.Ciorba_Alexandra_lab2newContext _context;

        public CreateModel(Ciorba_Alexandra_lab2new.Data.Ciorba_Alexandra_lab2newContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AuthorID"] = new SelectList(
                _context.Author
    .Select(a => new
    {
        a.ID,
        FullName = a.FirstName + " " + a.LastName
    }),
    "ID",
    "FullName"
);
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
"PublisherName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
