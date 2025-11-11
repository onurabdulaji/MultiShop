using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context
{
    public class DapperContext(IConfiguration configuration) : DbContext
    {
        private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ONURABDULAJI\\SQLEXPRESS;Initial Catalog=MultiShopDiscountDb;integrated security=true ; TrustServerCertificate=True");
        }
        public DbSet<Coupon> Coupons { get; set; }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
