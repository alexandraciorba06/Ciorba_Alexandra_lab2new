using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ciorba_Alexandra_lab2new.Models;

namespace Ciorba_Alexandra_lab2new.Data
{
    public class Ciorba_Alexandra_lab2newContext : DbContext
    {
        public Ciorba_Alexandra_lab2newContext (DbContextOptions<Ciorba_Alexandra_lab2newContext> options)
            : base(options)
        {
        }

        public DbSet<Ciorba_Alexandra_lab2new.Models.Book> Book { get; set; } = default!;
        public DbSet<Ciorba_Alexandra_lab2new.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Ciorba_Alexandra_lab2new.Models.Author> Author { get; set; } = default!;
    }
}
