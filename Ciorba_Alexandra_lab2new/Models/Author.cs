using System.ComponentModel.DataAnnotations;

namespace Ciorba_Alexandra_lab2new.Models
{
    public class Author
    {
       
            public int ID { get; set; }

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }
       


        [Display(Name = "Author")]
            public string FullName
            {
                get { return $"{LastName} {FirstName}"; }
            }
            public ICollection<Book>? Books { get; set; }
        }
    }
