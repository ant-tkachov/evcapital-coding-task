using System;

namespace EVCapital.CodingTask.Core.DomainModels
{
    /// <summary>
    /// The investor.
    /// </summary>
    public class Investor
    {
        /// <summary>
        /// The investor ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The investor first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The investor last name.
        /// </summary>
        public string LastName { get; set; }
    }
}
