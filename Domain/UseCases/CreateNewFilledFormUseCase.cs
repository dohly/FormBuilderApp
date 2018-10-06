using Domain.Entities;
using Domain.Gateways;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class CreateNewFilledFormUseCase
    {
        private readonly ISecurityService guard;
        private readonly User caller;

        public CreateNewFilledFormUseCase(
            ISecurityService guard,
            User caller)
        {
            this.guard = guard ?? throw new ArgumentNullException(nameof(guard));
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
        }

        public async Task Execute(FormObject newFormObject)
        {
            if (!await guard.CanCreateNewFormObjects(caller))
            {
                throw new UnauthorizedAccessException();
            }
            
        }
    }
}
