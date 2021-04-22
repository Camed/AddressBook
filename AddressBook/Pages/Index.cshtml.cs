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

        public IConfiguration configuration { get; }

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        public IndexModel(IConfiguration configuration, ILogger<IndexModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

            string query = "SELECT * FROM ProductDB";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            readSize = reader.FieldCount;
            while(reader.Read())
            {
                var p = new Product();
                int inner = 0;
                foreach (var x in reader)
                {
                    switch((int)inner)
                    {
                        case 0:
                            p.Id = x.ToString();
                            break;
                        case 1:
                            p.Maker = x.ToString();
                            break;
                        case 2:
                            p.Image = x.ToString();
                            break;
                        case 3:
                            p.Title = x.ToString();
                            break;
                        case 4:
                            p.Description = x.ToString();
                            break;
                        case 5:
                            p.Url = x.ToString();
                            break;
                    }
                    inner++;      
                }

                DBProducts.Append(p);
            }

            reader.Close();
            con.Close();
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
