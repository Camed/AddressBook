using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using AddressBook.Models;

namespace AddressBook.Pages
{
    public class FizzBuzzModel : PageModel
    {
        public FizzBuzz FizzBuzz { get; set; }
        public void OnGet()
        {
            var sessionAddress = HttpContext.Session.GetString("SessionAddress");
            if(sessionAddress != null)
            {
                FizzBuzz = JsonConvert.DeserializeObject<FizzBuzz>(sessionAddress);
                if(HttpContext.Session.Id == FizzBuzz.SessionId) History.AddElement(FizzBuzz);

            }       
        }
    }
}
