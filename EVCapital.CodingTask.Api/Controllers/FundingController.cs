using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using EVCapital.CodingTask.Api.ViewModels;
using EVCapital.CodingTask.BusinessLayer;
using EVCapital.CodingTask.Core.DomainModels;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace EVCapital.CodingTask.Api.Controllers
{
    /// <summary>
    /// Contains method to work with fundings.
    /// </summary>
    [Route("api/funding")]
    [ApiController]
    public class FundingController : ControllerBase
    {
        private readonly IFundingService _fundingService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Instantiates a new insatance of the controller.
        /// </summary>
        /// <param name="fundingService"></param>
        /// <param name="mapper"></param>
        public FundingController(IFundingService fundingService, IMapper mapper)
        {
            _fundingService = fundingService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets list of all fundings.
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        [SwaggerOperation("GetAllFundings")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int), Description = "The list of fundings.")]
        public async Task<IActionResult> GetAllFundingsAsync()
        {
            IEnumerable<Funding> fundings = await _fundingService.GetFundingsAsync();
            IEnumerable<FundingModel> result = _mapper.ProjectTo<FundingModel>(fundings.AsQueryable());

            return Ok(result);
        }

        /// <summary>
        /// Adds an investment to funding.
        /// </summary>
        /// <returns><see cref="IActionResult"/>.</returns>
        [HttpPost("invest")]
        [SwaggerOperation("Invest")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IActionResult), Description = "Invest money to a funding.")]
        public async Task<IActionResult> InvestAsync([FromBody]InvestRequestModel request)
        {
            await _fundingService.AddAmountAsync(request.FundingId, request.InvestorId, request.Amount);

            return Ok();
        }
    }
}
