using Domain.Entities;
using Domain.Gateways;
using System;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class CreateNewFilledForm
    {
        private readonly ISecurityService guard;
        private readonly IFormDataRepository repo;
        private readonly User caller;

        public CreateNewFilledForm(
            ISecurityService guard,
            IFormDataRepository repo,
            User caller)
        {
            this.guard = guard ?? throw new ArgumentNullException(nameof(guard));
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
        }

        public async Task Execute(FormObject newFormObject)
        {
            if (!await guard.CanCreateNewFormObjects(caller))
            {
                throw new UnauthorizedAccessException();
            }
            await repo.SaveForm(newFormObject);
        }
    }
}
