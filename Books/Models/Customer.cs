using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


    }
}
