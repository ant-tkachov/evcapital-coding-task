using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EVCapital.CodingTask.Core;
using EVCapital.CodingTask.Core.DomainModels;

namespace EVCapital.CodingTask.BusinessLayer
{
    /// <summary>
    /// Implements methods to work with fundings.
    /// </summary>
    public class FundingService : IFundingService
    {
        private const decimal MinInvestedAmount = 100;
        private const decimal MaxInvestedAmount = 10000;

        private readonly IFundingRepository _repository;

        public FundingService(IFundingRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Funding>> GetFundingsAsync()
        {
            return await _repository.GetFundingsAsync();
        }

        /// <inheritdoc />
        public async Task AddAmountAsync(Guid fundingId, Guid investorId, decimal amount)
        {
            Funding funding = await _repository.GetFundingAsync(fundingId);
            await ValidateAsync(funding, investorId, amount);

            funding.CollectedAmount += amount;
            funding.InvestorIds.Add(investorId);

            await _repository.AddAmountAsync(funding, investorId, amount);
        }

        private async Task ValidateAsync(Funding funding, Guid investorId, decimal amount)
        {
            if (amount < MinInvestedAmount)
            {
                throw new ArgumentException("The invested amount cannot be smalled than 100€.");
            }

            if (amount > MaxInvestedAmount)
            {
                throw new ArgumentException("The invested amount cannot bigger than 10000€.");
            }

            if (funding == null)
            {
                throw new ArgumentException("Funding does not exist.");
            }

            if (funding.InvestorIds.Contains(investorId))
            {
                throw new ArgumentException("The investor already invested.");
            }

            if (funding.CollectedAmount + amount > funding.GoalAmount)
            {
                throw new ArgumentException("The goal amount exceeded.");
            }
        }
    }
}
