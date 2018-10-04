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
        // GET api/values
        [HttpGet("Forms")]
        [Authorize]
        public Task<IActionResult> Get()
            => this.SafeExecute(async () =>
         {
             var result = await useCases.GetFormDefinitions(currentUser);
             return Ok(result.Select(x => x.ToDTO()));
         });        
    }
}
