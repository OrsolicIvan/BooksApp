using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public int CategoryDescription { get; set; }

        public ICollection<Book> Books { get; set; }    
    }
}
