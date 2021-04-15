using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using AddressBook.Data;

namespace AddressBook.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FizzBuzzContext _context;


        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        public IList<FizzBuzzDataModel> FizzBuzzDataModels { get; set; }
        public IndexModel(ILogger<IndexModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            FizzBuzzDataModels = _context.FizzBuzzData.ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                FizzBuzz.SessionId = HttpContext.Session.Id;
                HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(FizzBuzz));
                return RedirectToPage("./FizzBuzz");
            }
            return RedirectToPage("./Privacy");
        }
    }
}
