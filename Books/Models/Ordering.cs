using System.Collections;
using System.Collections.Generic;

namespace Books.Models
{
    public class Ordering
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int OrderId { get; set; }
        public Book_Order Book_Order { get; set; }

    }
}
