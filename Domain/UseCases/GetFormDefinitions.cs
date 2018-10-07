using Domain.Entities;
using Domain.Gateways;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class GetFormDefinitions
    {
        private readonly IMetadataRepository repository;
        private readonly ISecurityService guard;
        private readonly User requester;

        public GetFormDefinitions(IMetadataRepository repository, 
            ISecurityService guard,
            User requester)
        {
            this.repository = repository;
            this.guard = guard;
            this.requester = requester;
        }
        public async Task<IEnumerable<FormDefinition>> Execute()
        {
            //There is no such requirement in the task.
            //I just want to show difference between 'repository' and 'use-case'.
            if (!await guard.CanRetrieveFormDefinitions(requester))
            {
                throw new System.UnauthorizedAccessException();
            }
            return await repository.GetFormDefinitions();
        }        
    }
}
