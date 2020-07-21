using ChallengeFinalSandino.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChallengeFinalSandino.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        public DbSet<Expense> Expense { get; set; }
        public DbSet<Home_Expense> Home_Expense { get; set; }
        public DbSet<Expense_Detail> Expense_Detail { get; set; }
        public DbSet<Home_Expense_Detail> Home_Expense_Detail { get; set; }
    }
}
