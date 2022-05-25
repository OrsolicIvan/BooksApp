using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class Book_Order
    {
        [Key]
        public int OrderId { get; set; }
        public int OrderDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Ordering> Orderings { get; set; }
    }
}
