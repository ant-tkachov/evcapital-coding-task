using System;

namespace EVCapital.CodingTask.Core.DomainModels
{
    /// <summary>
    /// The funding per investor.
    /// </summary>
    public class FundingInvestor
    {
        /// <summary>
        /// The funding ID.
        /// </summary>
        public Guid FundingId { get; set; }

        /// <summary>
        /// The investor ID.
        /// </summary>
        public Guid InvestorId { get; set; }

        /// <summary>
        /// The amount of money invested by the investor into the funding.
        /// </summary>
        public decimal Amount { get; set; }
    }
}
