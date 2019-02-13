using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace EVCapital.CodingTask.Api.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private const string InvestorIdCookieName = "InvestorId";

        /// <summary>
        /// Returns an ID of the investor.
        /// </summary>
        /// <returns>ID to simulate a session of an investor.</returns>
        [HttpGet("id")]
        [SwaggerOperation("GetSessionId")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int), Description = "The session ID.")]
        public async Task<IActionResult> GetSessionIdAsync()
        {
            string value = Request.Cookies[InvestorIdCookieName];
            if (!Guid.TryParse(value, out var investorId))
            {
                investorId = Guid.NewGuid();
            }

            Response.Cookies.Append(InvestorIdCookieName, investorId.ToString());

            return Ok(investorId);
        }
    }
}
