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
using Microsoft.Extensions.Configuration;
using AddressBook.Services;
using System.Data.SqlClient;

namespace AddressBook.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        public int readSize { get; set; }
        public IEnumerable<Product> Products { get; private set; }
        public IConfiguration configuration { get; }

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        public IndexModel(IConfiguration configuration, ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            this.configuration = configuration;
            _logger = logger;
            Products = productService.GetProducts();
        }

        public void OnGet()
        {

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
