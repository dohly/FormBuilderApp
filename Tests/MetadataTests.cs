using Domain;
using Domain.Entities;
using Domain.Gateways;
using Domain.UseCases;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class MetadataTests
    {
        private IMetadataRepository repo = new InMemoryMetadataRepository();
        private GetFormDefinitionsUseCase getFormDefinitions(User caller) =>
            new GetFormDefinitionsUseCase(repo, new DummyGuard(), caller);
        private CreateNewFormDefinitionUseCase createNewFormDefinition(User caller) =>
            new CreateNewFormDefinitionUseCase(repo, new DummyGuard(), caller);

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
            var currentUser = new Admin();
            await this.createNewFormDefinition(currentUser).Execute(sampleForm);
            var formFromStorage = await repo.GetFormDefinitionById(sampleForm.Id);
            Assert.Equal(sampleForm.Id, formFromStorage.Id);
            Assert.Equal(sampleForm.Name, formFromStorage.Name);
        }
        //There is no such requirement in the task.
        //I want to show difference between repository and use-case.
        [Fact]
        public async Task OnlyAdminCanCreateForm()
        {
            await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
                createNewFormDefinition(new Employee()).Execute(sampleForm));
            await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
                createNewFormDefinition(new FiredEmployee()).Execute(sampleForm));
        }

        //There is no such requirement in the task.
        //I want to show difference between repository and use-case.
        [Fact]
        public Task FiredEmployeeCantAccessToFormList()
            => Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
                 getFormDefinitions(new FiredEmployee()).Execute());
        [Fact]
        public async Task AdminAndEmployeeCanAccessToFormList()
        {
            var r1 = await getFormDefinitions(new Admin()).Execute();
            var r2 = await getFormDefinitions(new Employee()).Execute();
            Assert.Equal(r1.Count(), r2.Count());
        }

    }
}
