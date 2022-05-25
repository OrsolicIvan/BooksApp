using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public List<Author_Book> Author_Books { get; set; }
        public List<Ordering> Orderings { get; set; }

        public int CategoryId { get; set; }
        public Category Categories { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string BookTitle { get; set; }

        [Column(TypeName = "nvarchar(4)")]
        public string BookYear { get; set; }
    }
}
