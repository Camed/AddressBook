using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public static class History
    {
        
        private static List<FizzBuzz> fbl = new List<FizzBuzz>();
        [Display(Name = "List")]
        public static List<FizzBuzz> FizzBuzzList { get => fbl; }
        public static void AddElement(FizzBuzz fb) => fbl.Add(fb);
    }
}

