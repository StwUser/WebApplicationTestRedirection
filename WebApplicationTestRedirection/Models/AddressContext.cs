using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationTestRedirection.Models
{
    public class AddressContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public AddressContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;UserId=root;Password=hello;database=addresses;");
        }
    }
}
