using Domain;
using Domain.Entities;
using Domain.UseCases;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class MetadataTests
    {
        private FormMetadataUseCases metadataUseCases=
            new FormMetadataUseCases(new InMemoryMetadataRepository(), new DummyGuard());
        private User admin = new User() { Name = "Admin" };
        private User firedEmployee= new User() { Name = "Fired employee" };
        private User regularUser = new User() { Name = "Employee" };

        [Fact]
        public void FormDefinitionNameCantBeEmpty() =>
            Assert.Throws<ArgumentException>(
                () => new FormDefinition(""));
        [Fact]
        public async Task FormDefinitionCreatedSuccessfully()
        {
            var form = new FormDefinition("User profile");
            await this.metadataUseCases.CreateNewFormDefinition(admin,form);            
            var formFromStorage = await metadataUseCases.GetFormDefinition(admin, form.Id);
            Assert.Equal(form.Id, formFromStorage.Id);
            Assert.Equal(form.Name, formFromStorage.Name);
        }
        [Fact]
        public async Task OnlyAdminCanCreateForm()
        {
            var form = new FormDefinition("User profile");
            await Assert.ThrowsAsync<UnauthorizedAccessException>(()=>
                metadataUseCases.CreateNewFormDefinition(regularUser, form));
            await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
                metadataUseCases.CreateNewFormDefinition(firedEmployee, form));
        }


    }
}
