using CarLoanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarLoanAPI
{
    public class MyDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MyDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("MyConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<LoanApplication> LoanApplications { get; set; }
    }
}
