using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Gateways;
using Domain.UseCases;
using Infrastructure.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetadataController : WebApiController
    {
        private readonly IMetadataRepository repo;

        public MetadataController(ISecurityService guard, IMetadataRepository repo) : base(guard)
        {
            this.repo = repo;
        }
        /// <summary>
        /// Get form definitions
        /// </summary>
        /// <response code="200">Form definitions</response>
        /// <response code="401">Invalid token</response> 
        /// <response code="500">Server error</response> 
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<FormDefinitionDTO>), 200)]
        public Task<IActionResult> Get()
            => this.SafeExecute(async (currentUser) =>
         {
             var result = await new GetFormDefinitionsUseCase(repo, Guard, currentUser).Execute();
             return Ok(result.Select(x => x.ToDTO()));
         });
        /// <summary>
        /// Get specific form definition
        /// </summary>
        /// <response code="200">Form definition</response>
        /// <response code="401">Invalid token</response> 
        /// <response code="404">Form definition not found</response> 
        /// <response code="500">Server error</response> 
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(FormDefinitionDTO), 200)]
        public Task<IActionResult> Get(string id)
            => this.SafeExecute(async (currentUser) =>
            {
                if (Guid.TryParse(id, out var guid))
                {
                    var result = await new GetSpecificFormDefinitionUseCase(repo,Guard,currentUser).Execute(guid);
                    return Ok(result.ToDTO());
                }
                return NotFound();
            });
    }
}
