using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Ciorba_Alexandra_lab2new.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Titlul este obligatoriu.")]
        [StringLength(150, MinimumLength = 3,
            ErrorMessage = "Titlul trebuie să aibă între 3 și 150 de caractere.")]
        [Display(Name = "Book Title")]
        public string Title { get; set; }

        public int? AuthorID { get; set; }
        public Author? Author { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }

        public ICollection<BookCategory>? BookCategories { get; set; }
    }

}
