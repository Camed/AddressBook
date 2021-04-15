using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using AddressBook.Models;
using AddressBook.Data;

namespace AddressBook.Pages
{
    public class FizzBuzzModel : PageModel
    {
        public FizzBuzz FizzBuzz { get; set; }
        public FizzBuzzContext FizzBuzzContext { get; set; }
        public void OnGet()
        {
            var sessionAddress = HttpContext.Session.GetString("SessionAddress");
            if (sessionAddress != null)
            {
                FizzBuzz = JsonConvert.DeserializeObject<FizzBuzz>(sessionAddress);
                FizzBuzzContext = new FizzBuzzContext();
                var date = DateTime.UtcNow;
                FizzBuzzContext.Add
                (
                    new FizzBuzzDataModel()
                    {
                        Id = FizzBuzz.SessionId.GetHashCode(),
                        DateTime = $"{date.Day}-{date.Month}-{date.Year} {date.Hour}:{date.Minute}:{date.Second}",
                        FizzBuzzNumber = FizzBuzz.fbNumber,
                        FizzBuzzResult = FizzBuzz.fbValue
                    }
                );
                if (HttpContext.Session.Id == FizzBuzz.SessionId) History.AddElement(FizzBuzz);

            }

        }
    }
}
