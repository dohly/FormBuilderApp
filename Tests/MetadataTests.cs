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
        private FormMetadataUseCases metadataUseCases =
            new FormMetadataUseCases(new InMemoryMetadataRepository(), new DummyGuard());
        private User admin = new User() { Name = "Admin" };
        private User firedEmployee = new User() { Name = "Fired employee" };
        private User regularUser = new User() { Name = "Employee" };
        private FormDefinition sampleForm = new FormDefinition("User profile")
            .WithTextField(displayName: "First name", key: "FN", optional: false)
            .WithTextField(displayName: "Last name", key: "LN", optional: false);
        [Fact]
        public void FormDefinitionNameCantBeEmpty() =>
            Assert.Throws<ArgumentException>(
                () => new FormDefinition(""));
        [Fact]
        public void FormDefinitionNameCantHaveDuplicatedKeys() =>
            Assert.Throws<InvalidOperationException>(
                () => new FormDefinition("Some form")
                .WithTextField(displayName: "First name", key: "FN", optional: false)
                .WithTextField(displayName: "Last name", key: "FN", optional: false)
                );
        [Fact]
        public void FormDefinitionNameCantHaveDuplicatedNames() =>
            Assert.Throws<InvalidOperationException>(
                () => new FormDefinition("Some form")
                .WithTextField(displayName: "First name", key: "FN", optional: false)
                .WithTextField(displayName: "First name", key: "LN", optional: false)
                );
        [Fact]
        public async Task FormDefinitionCreatedSuccessfully()
        {
            await this.metadataUseCases.CreateNewFormDefinition(admin, sampleForm);
            var formFromStorage = await metadataUseCases.GetFormDefinition(admin, sampleForm.Id);
            Assert.Equal(sampleForm.Id, formFromStorage.Id);
            Assert.Equal(sampleForm.Name, formFromStorage.Name);
        }
        //There is no such requirement in the task.
        //I want to show difference between repository and use-case.
        [Fact]
        public async Task OnlyAdminCanCreateForm()
        {
            await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
                metadataUseCases.CreateNewFormDefinition(regularUser, sampleForm));
            await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
                metadataUseCases.CreateNewFormDefinition(firedEmployee, sampleForm));
        }


    }
}
