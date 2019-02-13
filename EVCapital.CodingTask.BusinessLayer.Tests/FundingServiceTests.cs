using System;
using System.Threading.Tasks;
using EVCapital.CodingTask.Core;
using EVCapital.CodingTask.Core.DomainModels;
using NSubstitute;
using Xunit;

namespace EVCapital.CodingTask.BusinessLayer.Tests
{
    public class FundingServiceTests
    {
        private readonly IFundingRepository _repository;

        public FundingServiceTests()
        {
            _repository = Substitute.For<IFundingRepository>();
        }

        [Fact]
        public async Task AddAmountAsync_AmountIsTooSmall_Exception()
        {
            //arrange
            Guid fundingId = Guid.NewGuid();
            Guid investorId = Guid.NewGuid();
            decimal amount = 10;

            IFundingService service = new FundingService(_repository);
            await Assert.ThrowsAsync<ArgumentException>(() =>
                service.AddAmountAsync(fundingId, investorId, amount));
        }

        [Fact]
        public async Task AddAmountAsync_AmountIsTooBig_Exception()
        {
            //arrange
            Guid fundingId = Guid.NewGuid();
            Guid investorId = Guid.NewGuid();
            decimal amount = 100000;

            IFundingService service = new FundingService(_repository);
            await Assert.ThrowsAsync<ArgumentException>(() =>
                service.AddAmountAsync(fundingId, investorId, amount));
        }

        [Fact]
        public async Task AddAmountAsync_FundingNotFound_Exception()
        {
            //arrange
            Guid fundingId = Guid.NewGuid();
            Guid investorId = Guid.NewGuid();
            decimal amount = 1000;

            IFundingService service = new FundingService(_repository);
            await Assert.ThrowsAsync<ArgumentException>(() =>
                service.AddAmountAsync(fundingId, investorId, amount));
        }

        [Fact]
        public async Task AddAmountAsync_AlreadyInvested_Exception()
        {
            //arrange
            Guid fundingId = Guid.NewGuid();
            Guid investorId = Guid.NewGuid();
            decimal amount = 1000;

            Funding funding = new Funding
            {
                Id = Guid.NewGuid(),
                Name = "Fund 1",
                Description = "The description of the Fund 1",
                GoalAmount = 75000,
                InvestorIds = { investorId }
            };

            _repository.GetFundingAsync(Arg.Any<Guid>()).Returns(funding);

            IFundingService service = new FundingService(_repository);
            await Assert.ThrowsAsync<ArgumentException>(() =>
                service.AddAmountAsync(fundingId, investorId, amount));
        }

        [Fact]
        public async Task AddAmountAsync_GoalAmountExceeded_Exception()
        {
            //arrange
            Guid fundingId = Guid.NewGuid();
            Guid investorId = Guid.NewGuid();
            decimal amount = 5000;

            Funding funding = new Funding
            {
                Id = Guid.NewGuid(),
                Name = "Fund 1",
                Description = "The description of the Fund 1",
                CollectedAmount = 74000,
                GoalAmount = 75000
            };

            _repository.GetFundingAsync(Arg.Any<Guid>()).Returns(funding);

            IFundingService service = new FundingService(_repository);
            await Assert.ThrowsAsync<ArgumentException>(() =>
                service.AddAmountAsync(fundingId, investorId, amount));
        }

        [Fact]
        public async Task AddAmountAsync_AllParamsAreCorrect_Ok()
        {
            //arrange
            Guid fundingId = Guid.NewGuid();
            Guid investorId = Guid.NewGuid();
            decimal amount = 5000;

            Funding funding = new Funding
            {
                Id = Guid.NewGuid(),
                Name = "Fund 1",
                Description = "The description of the Fund 1",
                GoalAmount = 75000
            };

            _repository.GetFundingAsync(Arg.Any<Guid>()).Returns(funding);

            //act
            IFundingService service = new FundingService(_repository);
            await service.AddAmountAsync(fundingId, investorId, amount);

            //assert
            Assert.Equal(amount, funding.CollectedAmount);
            Assert.Contains(investorId, funding.InvestorIds);
            await _repository.Received(1).AddAmountAsync(funding, investorId, amount);
        }
    }
}
