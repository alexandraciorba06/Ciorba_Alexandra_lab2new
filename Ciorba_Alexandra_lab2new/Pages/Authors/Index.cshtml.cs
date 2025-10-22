using Ciorba_Alexandra_lab2new.Data;
using Ciorba_Alexandra_lab2new.Models;
using Ciorba_Alexandra_lab2new.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciorba_Alexandra_lab2new.Pages.Authors

{
    public class IndexModel : PageModel
    {
        private readonly Ciorba_Alexandra_lab2new.Data.Ciorba_Alexandra_lab2newContext _context;

        public IndexModel(Ciorba_Alexandra_lab2new.Data.Ciorba_Alexandra_lab2newContext context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync(int? id)
        {
           Author = await _context.Author
                .ToListAsync();
            {
            }
        }
    }
}
