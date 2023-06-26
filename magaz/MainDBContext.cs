using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shop.models;

namespace Shop
{
    public class MainDBContext:DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Seller> sellers { get; set; }
        public MainDBContext() {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=192.168.0.222;user=root;password=is410601;database=vadartko");
        }
    }
}
