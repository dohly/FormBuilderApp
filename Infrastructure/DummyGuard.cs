using Domain.Entities;
using Domain.Gateways;
using System;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DummyGuard : ISecurityService
    {
        public Task<bool> CanCreateNewForms(User requester) => Task.FromResult(requester.Name == "Admin");
        public Task<bool> CanRetrieveFormDefinition(User user, Guid formDefinitionId)
            => Task.FromResult(user.Name != "Fired employee");
    }
}
