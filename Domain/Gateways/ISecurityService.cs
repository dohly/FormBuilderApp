using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Gateways
{
    public interface ISecurityService
    {
        Task<bool> CanRetrieveSpecificFormDefinition(User user, Guid formDefinitionId);
        Task<bool> CanRetrieveFormDefinitions(User user);
        Task<bool> CanCreateNewForms(User requester);
    }
}
