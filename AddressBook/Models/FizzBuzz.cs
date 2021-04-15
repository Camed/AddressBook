using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AddressBook.Models
{
    public class FizzBuzz
    { 
        [Display(Name="FizzBuzz")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter proper number!"), Required(ErrorMessage = "You need to fill this field!")]
        public int fbNumber { get; set; }

        public string SessionId { get; set; }
        public string DateTime { get; set; }

        [Display(Name="Answer")]
        public string fbValue 
        {
            get
            {
                var result = "";
                if (fbNumber % 3 == 0) result += "Fizz";
                if (fbNumber % 5 == 0) result += "Buzz";
                if (result == "") result += fbNumber.ToString();
                return result.ToString();
            }
        }
    }
}