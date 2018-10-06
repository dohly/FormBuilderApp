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
                new Admin()
                {
                    Name="Admin",
                    Login="admin",
                    Password="admin_pwd" //no hashing for now
                },
                new Employee()
                {
                    Name="Employee",
                    Login="employee",
                    Password="employee_pwd" //no hashing for now
                },
                new FiredEmployee()
                {
                    Name="Fired employee",
                    Login="f_employee",
                    Password="f_employee_pwd" //no hashing for now
                }
            };

        public Task<bool> CanCreateNewFormObjects(User requester)
            => Task.FromResult(!(requester is FiredEmployee));

        public Task<bool> CanCreateNewForms(User requester)
            => Task.FromResult(requester is Admin);

        public Task<bool> CanRetrieveFormDefinitions(User user)
            => Task.FromResult(!(user is FiredEmployee));

        public Task<bool> CanRetrieveSpecificFormDefinition(User user, Guid formDefinitionId)
            => Task.FromResult(!(user is FiredEmployee));

        public Task<User> GetUserByCredentials(string login, string password)
        {            
            return Task.FromResult(TestUsers.FirstOrDefault(x => x.Login == login 
            && x.Password == password));//no hash for now
        }

        public Task<User> GetUserByName(string name)
            => Task.FromResult(TestUsers.FirstOrDefault(x => x.Name == name));
    }
}
