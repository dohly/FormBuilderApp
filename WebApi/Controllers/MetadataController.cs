using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Gateways;
using Domain.UseCases;
using Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        // GET api/values
        [HttpGet("Forms")]
        public async Task<ActionResult<IEnumerable<FormDefinitionDTO>>> Get(
            [FromServices]IMetadataRepository repository,
            [FromServices]ISecurityService guard
            )
        {
            var user = new User() { Name = "Someone" };
            var result = await (new FormMetadataUseCases(repository, guard).GetFormDefinitions(user));
            return Ok(result.Select(x => x.ToDTO()));
        }
        [HttpGet("Forms/{id}")]
        public async Task<ActionResult<FormDefinition>> GetSpecific(Guid id,
            [FromServices]IMetadataRepository repository,
            [FromServices]ISecurityService guard
            )
        {
            var user = new User() { Name = "Someone" };
            return Ok(await new FormMetadataUseCases(repository, guard).GetFormDefinition(user, id));
        }
    }
}
