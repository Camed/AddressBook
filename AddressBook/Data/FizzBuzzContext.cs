using AddressBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Data
{
    public class FizzBuzzContext : DbContext
    {
        public FizzBuzzContext()
        {
        }

        public FizzBuzzContext(DbContextOptions options) : base(options) { }
        public DbSet<FizzBuzzDataModel> FizzBuzzData { get; set; }
    }
}
