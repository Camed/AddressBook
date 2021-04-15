using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AddressBook.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using AddressBook.Data;
using System.Globalization;

namespace AddressBook.Pages
{
    public class HistoryModel : PageModel
    {

        public List<FizzBuzz> fizzBuzzList { get => History.FizzBuzzList; }    
        public List<FizzBuzzContext> fizzBuzzContexts { get => History.FizzBuzzDataModels;  }
        public void OnGet()
        {
            
        }
    }
}
