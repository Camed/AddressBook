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
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Text;

namespace AddressBook.Pages
{
    public class FizzBuzzModel : PageModel
    {
        public FizzBuzz FizzBuzz { get; set; }
        public FizzBuzzContext FizzBuzzContext { get; set; }

        public string output { get; set; }
        public IConfiguration configuration { get; }
        public FizzBuzzModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void OnGet()
        {
            string connectionString = configuration.GetConnectionString("FizzBuzzDb");
            SqlConnection con = new SqlConnection(connectionString);
            
            string query = "SELECT TOP 10 * FROM FizzBuzzData ORDER BY DateTime DESC";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            StringBuilder sb = new StringBuilder("");

            while (reader.Read())
            {
                sb.Append("<li>");
                sb.Append(reader[0].ToString() + " ");
                sb.Append(reader[1].ToString() + " ");
                sb.Append(reader[2].ToString() + " ");
                sb.Append(reader[3].ToString() + " ");
                sb.Append("</li>");
            }
            reader.Close();
            con.Close();

            output = sb.ToString();

            var sessionAddress = HttpContext.Session.GetString("SessionAddress");
            if (sessionAddress != null)
            {
                FizzBuzz = JsonConvert.DeserializeObject<FizzBuzz>(sessionAddress);
                FizzBuzzContext = new FizzBuzzContext();
                FizzBuzzContext.Add
                (
                    new FizzBuzzDataModel()
                    {
                        Id = FizzBuzz.SessionId.GetHashCode(),
                        DateTime = FizzBuzz.DateTime,
                        FizzBuzzNumber = FizzBuzz.fbNumber,
                        FizzBuzzResult = FizzBuzz.fbValue
                    }
                );
                if (HttpContext.Session.Id == FizzBuzz.SessionId) History.AddElement(FizzBuzz);
                History.AddElement(FizzBuzzContext);

            }

        }
    }
}
