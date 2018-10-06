using Domain.Entities;
using Domain.Gateways;
using Domain.UseCases;
using Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class MetadataTests
    {
        private IMetadataRepository repo = new InMemoryMetadataRepository();
        private GetFormDefinitions getFormDefinitions(User caller) =>
            new GetFormDefinitions(repo, new DummyGuard(), caller);
        private CreateNewFormDefinition createNewFormDefinition(User caller) =>
            new CreateNewFormDefinition(repo, new DummyGuard(), caller);

        private FormDefinition sampleForm = new FormDefinition("User profile")
            .WithTextField(() => new TextFieldDefinition(name: "First name", fieldKey: "FN", required: true))
            .WithTextField(() => new TextFieldDefinition(name: "Last name", fieldKey: "LN", required: true));
        [Fact]
        public void FormDefinitionNameCantBeEmpty() =>
            Assert.Throws<ArgumentException>(
                () => new FormDefinition(""));
        [Fact]
        public void FormDefinitionNameCantHaveDuplicatedKeys() =>
            Assert.Throws<InvalidOperationException>(
                () => new FormDefinition("Some form")
                .WithTextField(() => new TextFieldDefinition(name: "First name", fieldKey: "FN", required: true))
                .WithTextField(() => new TextFieldDefinition(name: "Last name", fieldKey: "FN", required: true)));
        [Fact]
        public void FormDefinitionNameCantHaveDuplicatedNames() =>
            Assert.Throws<InvalidOperationException>(
                () => new FormDefinition("Some form")
                .WithTextField(() => new TextFieldDefinition(name: "First name", fieldKey: "FN", required: true))
                .WithTextField(() => new TextFieldDefinition(name: "First name", fieldKey: "LN", required: true)));
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
