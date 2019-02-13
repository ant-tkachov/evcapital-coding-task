using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EVCapital.CodingTask.Core.DomainModels;

namespace EVCapital.CodingTask.Core
{
    public interface IFundingRepository
    {
        /// <summary>
        /// Gets a funding by ID.
        /// </summary>
        /// <param name="id">The funding ID.</param>
        /// <returns></returns>
        Task<Funding> GetFundingAsync(Guid id);

        /// <summary>
        /// Get existing fundings.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Funding>> GetFundingsAsync();

        /// <summary>
        /// Adds amount per investor into the funding.
        /// </summary>
        /// <param name="funding">The <see cref="Funding"/>.</param>
        /// <param name="investorId">The <see cref="Investor"/> ID></param>
        /// <param name="amount">The invested amount of money.</param>
        /// <returns></returns>
        Task AddAmountAsync(Funding funding, Guid investorId, decimal amount);
    }
}
