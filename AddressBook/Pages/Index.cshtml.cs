using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
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
            this.configuration = configuration;
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                FizzBuzz.SessionId = HttpContext.Session.Id;
                var date = DateTime.UtcNow;
                FizzBuzz.DateTime = $"{date.Day}-{date.Month}-{date.Year} {date.Hour}:{date.Minute}:{date.Second}";
                HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(FizzBuzz));

                string connectionString = configuration.GetConnectionString("FizzBuzzDb");

                SqlConnection con = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand("sp_FizzBuzzAdd", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter id_param = new SqlParameter("@id", System.Data.SqlDbType.Int);
                id_param.Value = HttpContext.Session.Id.GetHashCode();
                cmd.Parameters.Add(id_param);

                SqlParameter fizzbuzznumber_param = new SqlParameter("@FizzBuzzNumber", System.Data.SqlDbType.Int);
                fizzbuzznumber_param.Value = FizzBuzz.fbNumber;
                cmd.Parameters.Add(fizzbuzznumber_param);

                SqlParameter fizzbuzzresult_param = new SqlParameter("@FizzBuzzResult", System.Data.SqlDbType.VarChar, 100);
                fizzbuzzresult_param.Value = FizzBuzz.fbValue;
                cmd.Parameters.Add(fizzbuzzresult_param);

                SqlParameter datetime_param = new SqlParameter("@DateTime", System.Data.SqlDbType.VarChar, 100);
                datetime_param.Value = FizzBuzz.DateTime;
                cmd.Parameters.Add(datetime_param);

                con.Open();
                int num = cmd.ExecuteNonQuery();
                con.Close();

                _logger.LogInformation($"{DateTime.UtcNow.ToLongDateString()} {DateTime.UtcNow.ToLongTimeString()} - Inserted {num} rows into DB.");
                    
                return RedirectToPage("./FizzBuzz");
            }
            return RedirectToPage("./Privacy");
        }
    }
}
