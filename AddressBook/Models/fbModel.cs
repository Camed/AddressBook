using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class FizzBuzzDataModel
    {
        public int Id { get; set; }
        public int FizzBuzzNumber { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string FizzBuzzResult { get; set; }

        [Required]
        [MaxLength(100)]
        public string DateTime { get; set; }
    }
}
