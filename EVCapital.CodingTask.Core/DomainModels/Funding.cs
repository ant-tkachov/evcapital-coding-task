using System;
using System.Collections.Generic;

namespace EVCapital.CodingTask.Core.DomainModels
{
    /// <summary>
    /// The funding.
    /// </summary>
    public class Funding
    {
        public Funding()
        {
            InvestorIds = new List<Guid>();
        }

        /// <summary>
        /// The funding ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The funding Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The funding description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The funding goal.
        /// </summary>
        public decimal GoalAmount { get; set; }

        /// <summary>
        /// The amount of money already collected.
        /// </summary>
        public decimal CollectedAmount { get; set; }

        /// <summary>
        /// The collection of investor IDs which alread invested some money.
        /// </summary>
        public IList<Guid> InvestorIds { get; set; }
    }
}
