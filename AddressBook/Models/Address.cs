using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    
    public class Address
    {
        [Display(Name = "Twoja ulubiona ulica")]
        [StringLength(60, MinimumLength = 3), Required(ErrorMessage = "Pole jest obowiązkowe!")]
        public string Street { get; set; }

        [Display(Name = "Twój ulubiony kod pocztowy")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Podaj poprawny kod pocztowy!"), Required(ErrorMessage = "Pole jest obowiązkowe!")]
        public string ZipCode { get; set; }

        [Display(Name = "Twoje ulubione miasto")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Podaj poprawną nazwę miasta!"), Required(ErrorMessage = "Pole jest obowiązkowe!")]
        public string City { get; set; }

        [Display(Name = "Twój ulubiony numer")]
        [Range(0, int.MaxValue, ErrorMessage = "Proszę podać poprawny numer!"), Required(ErrorMessage = "Pole jest obowiązkowe!")]
        public int Number { get; set; }

    }
}
