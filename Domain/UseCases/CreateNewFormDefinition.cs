using Domain.Entities;
using Domain.Gateways;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class CreateNewFormDefinition
    {
        private readonly IMetadataRepository repository;
        private readonly ISecurityService guard;
        private readonly User requester;

        public CreateNewFormDefinition(IMetadataRepository repository, 
            ISecurityService guard,
            User requester)
        {
            this.repository = repository;
            this.guard = guard;
            this.requester = requester;
        }
      
        public async Task Execute(FormDefinition form)
        {
            //There is no such requirement in the task.
            //I just want to show difference between repository and use-case.
            if (!await guard.CanCreateNewForms(requester))
            {
                throw new System.UnauthorizedAccessException();
            }            
            await repository.CreateFormDefinition(form);
        }        
    }
}
