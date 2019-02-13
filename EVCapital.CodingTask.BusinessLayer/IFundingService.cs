using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EVCapital.CodingTask.Core.DomainModels;

namespace EVCapital.CodingTask.BusinessLayer
{
    /// <summary>
    /// Defines methods to work with fundings.
    /// </summary>
    public interface IFundingService
    {
        /// <summary>
        /// Gets collection of existing fundings.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Funding>> GetFundingsAsync();

        /// <summary>
        /// Adds amount per investor into the funding.
        /// </summary>
        /// <param name="fundingId">The funding ID to inest to.</param>
        /// <param name="investorId">The investor ID.</param>
        /// <param name="amount">The invested amount.</param>
        /// <returns></returns>
        Task AddAmountAsync(Guid fundingId, Guid investorId, decimal amount);
    }
}
