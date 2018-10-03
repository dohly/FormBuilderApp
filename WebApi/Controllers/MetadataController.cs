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
        private MetadataUseCases useCases;
        public MetadataController(IMetadataRepository repository, ISecurityService guard)
        {
            useCases = new MetadataUseCases(repository, guard);
        }
        // GET api/values
        [HttpGet("Forms")]
        public async Task<ActionResult<IEnumerable<FormDefinitionDTO>>> Get()
        {
            var user = new User() { Name = "Someone" };
            var result = await useCases.GetFormDefinitions(user);
            return Ok(result.Select(x => x.ToDTO()));
        }
        [HttpGet("Forms/{id}")]
        public async Task<ActionResult<FormDefinition>> GetSpecific(Guid id)
        {
            var user = new User() { Name = "Someone" };
            return Ok((await useCases.GetFormDefinition(user, id)).ToDTO());
        }
    }
}
