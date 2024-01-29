using FFG.Application.Contracts.Services;
using FFG.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FFG.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CodeValueController : BaseController<ICodeValueService>
    {
        /// <summary>
        /// Gets CodeValues by query.
        /// </summary>
        /// <param name="query">Query for find.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// Sample request:
        /// GET /CodeValue/?query=7
        /// </remarks>
        /// <returns>Returns CodeValues.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CodeValue>>> GetAllWithFilter(string? query, CancellationToken cancellationToken)
        {
            return Ok(await Service.GetAllWithFilter(query, cancellationToken));
        }

        /// <summary>
        /// Creates the CodeValues.
        /// </summary>
        /// <param name="createCodeValues">CreateCodeValues object.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// Sample request:
        /// POST /CodeValue
        /// {
        ///     code: "12"
        ///     value: "Priv sho ty?"
        /// }
        /// </remarks>
        /// <returns>Returns NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)] //TODO: нужно тоже DTO для создания и маппинг
        public async Task<ActionResult> Create([Required] IEnumerable<CodeValue> createCodeValues, CancellationToken cancellationToken)
        {
            await Service.Create(createCodeValues, cancellationToken);
            return NoContent();
        }
    }
}
