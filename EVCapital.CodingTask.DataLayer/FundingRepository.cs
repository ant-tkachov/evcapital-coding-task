using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EVCapital.CodingTask.Core;
using EVCapital.CodingTask.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EVCapital.CodingTask.DataLayer
{
    /// <summary>
    /// Implements repository which stores data in the database.
    /// </summary>
    public class FundingRepository : IFundingRepository
    {
        private readonly EVCapitalDbContext _context;

        public FundingRepository(EVCapitalDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Funding> GetFundingAsync(Guid id)
        {
            return await _context.Fundings.FirstOrDefaultAsync(f => f.Id == id);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Funding>> GetFundingsAsync()
        {
            return await _context.Fundings.ToListAsync();
        }

        /// <inheritdoc />
        public async Task AddAmountAsync(Funding funding, Guid investorId, decimal amount)
        {
            using (IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync())
            {
                _context.Fundings.Update(funding);

                _context.FundingInvestors.Add(
                    new FundingInvestor
                        {
                            FundingId = funding.Id,
                            InvestorId = investorId,
                            Amount = amount
                        });

                await _context.SaveChangesAsync();

                transaction.Commit();
            }
        }
    }
}
