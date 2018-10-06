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
    public class MetadataController : ControllerBase
    {
        private MetadataUseCases useCases;
        private User currentUser => new User() { Name = User.Identity.Name };// simplified for demo
        public MetadataController(IMetadataRepository repository, ISecurityService guard)
        {
            useCases = new MetadataUseCases(repository, guard);
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
            => this.SafeExecute(async () =>
         {
             var result = await useCases.GetFormDefinitions(currentUser);
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
            => this.SafeExecute(async () =>
            {
                if (Guid.TryParse(id, out var guid))
                {
                    var result = await useCases.GetFormDefinition(currentUser, guid);
                    return Ok(result.ToDTO());
                }
                return NotFound();
            });
    }
}
