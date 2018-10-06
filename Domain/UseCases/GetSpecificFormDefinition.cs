using Domain.Entities;
using Domain.Exceptions;
using Domain.Gateways;
using System;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class GetSpecificFormDefinition
    {
        private readonly IMetadataRepository repository;
        private readonly ISecurityService guard;
        private readonly User requester;

        public GetSpecificFormDefinition(IMetadataRepository repository, 
            ISecurityService guard,
            User requester)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.guard = guard ?? throw new ArgumentNullException(nameof(guard));
            this.requester = requester ?? throw new ArgumentNullException(nameof(requester));
        }
      
        public async Task<FormDefinition> Execute(Guid id)
        {
            //There is no such requirement in the task.
            //I just want to show difference between repository and use-case.
            if (!await guard.CanRetrieveSpecificFormDefinition(requester, id))
            {
                throw new System.UnauthorizedAccessException();
            }
            var form = await repository.GetFormDefinitionById(id);     
            if (form == null)
            {
                throw new NotFoundException();
            }
            return form;
        }
        
    }
}
