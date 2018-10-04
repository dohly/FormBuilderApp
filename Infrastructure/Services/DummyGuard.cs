using Domain.Entities;
using Domain.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DummyGuard : ISecurityService
    {
        // Just for demo
        public static IEnumerable<User> TestUsers = new List<User>()
            {
                new User()
                {
                    Name="Admin",
                    Login="admin",
                    Password="admin_pwd" //no hashing for now
                },
                new User()
                {
                    Name="Employee",
                    Login="employee",
                    Password="employee_pwd" //no hashing for now
                },
                new User()
                {
                    Name="Fired employee",
                    Login="f_employee",
                    Password="f_employee_pwd" //no hashing for now
                }
            };
        public Task<bool> CanCreateNewForms(User requester)
            => Task.FromResult(requester.Name == "Admin");

        public Task<bool> CanRetrieveFormDefinitions(User user)
            => Task.FromResult(user.Name != "Fired employee");

        public Task<bool> CanRetrieveSpecificFormDefinition(User user, Guid formDefinitionId)
            => Task.FromResult(user.Name != "Fired employee");

        public Task<User> GetUserByCredentials(string login, string password)
        {            
            return Task.FromResult(TestUsers.FirstOrDefault(x => x.Login == login 
            && x.Password == password));//no hash for now
        }
    }
}
