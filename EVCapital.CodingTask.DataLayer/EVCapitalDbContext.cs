using EVCapital.CodingTask.Core.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace EVCapital.CodingTask.DataLayer
{
    /// <summary>
    /// The data context.
    /// </summary>
    public class EVCapitalDbContext : DbContext
    {
        /// <inheritdoc />
        public EVCapitalDbContext(DbContextOptions<EVCapitalDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// The fundings.
        /// </summary>
        public DbSet<Funding> Fundings => Set<Funding>();

        /// <summary>
        /// The fundings per investors.
        /// </summary>
        public DbSet<FundingInvestor> FundingInvestors => Set<FundingInvestor>();

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funding>().HasKey(f => f.Id);

            modelBuilder.Entity<FundingInvestor>().HasKey(fi => new { fi.FundingId, fi.InvestorId });
        }
    }
}
