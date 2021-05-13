using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Data;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AddressBook.Pages
{
    public class FromDataBaseModel : PageModel
    {
        private readonly ProductContext _context;

        [BindProperty]
        public IEnumerable<Product> Products { get; set; }
        public FromDataBaseModel(ProductContext context)
        {
            _context = context;
        }
        
        public void OnGet()
        {
            Products = _context.Product.ToList();
        }
    }
}
