using System;
using System.Collections.Generic;

namespace EVCapital.CodingTask.Api.ViewModels
{
    /// <summary>
    /// The funding view model.
    /// </summary>
    public class FundingModel
    {
        /// <summary>
        /// The funding ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The funding name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The funding description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The funding goal amount.
        /// </summary>
        public decimal GoalAmount { get; set; }

        /// <summary>
        /// The funding already collected amount.
        /// </summary>
        public decimal CollectedAmount { get; set; }

        /// <summary>
        /// The collection of IDs of the investors.
        /// </summary>
        public IList<Guid> InvestorIds { get; set; }
    }
}
