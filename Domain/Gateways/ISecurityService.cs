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
        Task<bool> CanCreateNewForms(User user);
        Task<bool> CanCreateNewFormObjects(User user);
        Task<User> GetUserByCredentials(string login, string password);
        Task<User> GetUserByName(string name);
        Task<bool> CanRetrieveFormObjects(Guid formDefinitionId, User user);
    }
}
