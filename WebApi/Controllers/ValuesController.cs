using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Gateways;
using Domain.UseCases;
using Infrastructure.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : WebApiController
    {
        public ValuesController(ISecurityService guard) : base(guard)
        {
        }

        /// <summary>
        /// Create new form object
        /// </summary>
        /// <param name="formId">Form definition id</param>
        /// <param name="obj">Dynamic for object</param>
        /// <response code="201">Succesfully created</response>
        /// <response code="401">Invalid token</response> 
        /// <response code="400">Invalid data or formId</response> 
        /// <response code="500">Server error</response> 
        [HttpPost("{formId}")]
        [Authorize]
        [ProducesResponseType(typeof(ValidationError), 400)]
        public Task<IActionResult> Create(Guid formId,
            [FromBody]JObject obj,
            [FromServices]IMetadataRepository metadataRepo,
            [FromServices]IFormDataRepository formRepo
            )
            => this.SafeExecute(async (currentUser) =>
            {
                var formDefinition = await new GetSpecificFormDefinition(metadataRepo, Guard, currentUser).Execute(formId);
                await new CreateNewFilledForm(Guard, formRepo, currentUser).Execute(
                    new Domain.Entities.FormObject(formDefinition, obj)
                    );
                return StatusCode(201);
            });

        [HttpGet("{formId}")]
        [Authorize]
        [ProducesResponseType(typeof(ObjectListDTO), 200)]
        public Task<IActionResult> Get(Guid formId,
            [FromServices]IMetadataRepository metadataRepo,
            [FromServices]IFormDataRepository formRepo)
            => this.SafeExecute(async (currentUser) =>
            {
                var formDefinition = await new GetSpecificFormDefinition(metadataRepo, Guard, currentUser).Execute(formId);
                var objects = await new GetFormObjests(Guard, formRepo, currentUser).Execute(formId);
                return Ok(new ObjectListDTO
                {
                    FormDefinition = formDefinition.ToDTO(),
                    Objects = objects.Select(x=>JObject.FromObject(x.Values)).ToList()
                });
            });
    }
}