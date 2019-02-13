using System;

namespace EVCapital.CodingTask.Api.ViewModels
{
    /// <summary>
    /// A request contains data required to store amount of invested money.
    /// </summary>
    public class InvestRequestModel
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
        /// The amount of invested money.
        /// </summary>
        public decimal Amount { get; set; }
    }
}
