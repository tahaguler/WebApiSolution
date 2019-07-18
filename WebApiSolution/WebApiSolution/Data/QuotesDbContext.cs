using Microsoft.EntityFrameworkCore;
using WebApiSolution.Models;

namespace WebApiSolution.Data
{
    public class QuotesDbContext : DbContext
    {
        public QuotesDbContext(DbContextOptions<QuotesDbContext> options) : base(options)
        {

        }
        public DbSet<Quote> Quotes { get; set; }
    }
}
