using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVCapital.CodingTask.Core;
using EVCapital.CodingTask.Core.DomainModels;

namespace EVCapital.CodingTask.DataLayer
{
    /// <summary>
    /// Implements dummy repository which stores data in memory.
    /// </summary>
    public class FundingInMemoryRepository : IFundingRepository
    {
        private readonly ConcurrentBag<Funding> _fundings;
        private readonly ConcurrentBag<FundingInvestor> _fundingInvestors;

        public FundingInMemoryRepository()
        {
            _fundings = new ConcurrentBag<Funding>
            {
                new Funding
                {
                    Id = Guid.NewGuid(),
                    Name = "Fund 1",
                    Description = "The description of the Fund 1",
                    GoalAmount = 75000
                },
                new Funding
                {
                    Id = Guid.NewGuid(),
                    Name = "Fund 2",
                    Description = "The description of the Fund 2",
                    GoalAmount = 85000
                },
                new Funding
                {
                    Id = Guid.NewGuid(),
                    Name = "Fund 3",
                    Description = "The description of the Fund 3",
                    GoalAmount = 55000
                },
                new Funding
                {
                    Id = Guid.NewGuid(),
                    Name = "Fund 4",
                    Description = "The description of the Fund 4",
                    GoalAmount = 95000
                }
            };

            _fundingInvestors = new ConcurrentBag<FundingInvestor>();
        }

        /// <inheritdoc />
        public async Task<Funding> GetFundingAsync(Guid id)
        {
            return _fundings.SingleOrDefault(f => f.Id == id);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Funding>> GetFundingsAsync()
        {
            return _fundings;
        }

        /// <inheritdoc />
        public async Task AddAmountAsync(Funding funding, Guid investorId, decimal amount)
        {
            Funding entity = _fundings.Single(f => f.Id == funding.Id);
            entity.CollectedAmount = funding.CollectedAmount;
            entity.InvestorIds = funding.InvestorIds;

            _fundingInvestors.Add(new FundingInvestor
            {
                FundingId = funding.Id,
                InvestorId = investorId,
                Amount = amount
            });
        }
    }
}
