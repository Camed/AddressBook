using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Data;

namespace AddressBook.Models
{
    public static class History
    {
        
        private static List<FizzBuzz> fbl = new List<FizzBuzz>();
        private static List<FizzBuzzContext> fbdm = new List<FizzBuzzContext>();
        [Display(Name = "List")]
        public static List<FizzBuzz> FizzBuzzList { get => fbl; }

        [Display(Name = "FbDmLst")]
        public static List<FizzBuzzContext> FizzBuzzDataModels { get => fbdm; }
        public static void AddElement(FizzBuzz fb) => fbl.Add(fb);
        public static void AddElement(FizzBuzzContext fbd) => fbdm.Add(fbd);
    }
}

