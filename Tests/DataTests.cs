using Domain;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Gateways;
using Domain.UseCases;
using Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class DataTests
    {
        private JObject fromJson(string json) => JsonConvert.DeserializeObject<JObject>(json);
        private IFormDataRepository repo = new InMemoryFormDataRepository();
        private CreateNewFilledFormUseCase createFormData(User caller) =>
            new CreateNewFilledFormUseCase(new DummyGuard(), repo, caller);
        private FormDefinition sampleForm = new FormDefinition("User profile")
            .WithTextField(displayName: "First name", key: "FN", requred: true)
            .WithTextField(displayName: "Last name", key: "LN", requred: true);

        [Fact]
        public void CannotCreateFormObjectIfRequiredValueIsEmpty()
            => Assert.Throws<ValidationException>(
                () => new FormObject(sampleForm, fromJson("{'FN':''}")));
        [Fact]
        public void CannotCreateFormObjectIfNoValuesReceived()
            => Assert.Throws<ValidationException>(
                () => new FormObject(sampleForm, fromJson("{}")));
        [Fact]
        public void CanCreateFormObjectIfValuesAreValid()
            => Assert.NotNull(new FormObject(sampleForm,
                fromJson("{ 'FN':'first name' ,'LN':'last name' }")));
        [Fact]
        public async Task FullSuccessExample()
        {
            string json = "{ 'FN':'first name' ,'LN':'last name' }";
            var obj = new FormObject(sampleForm, fromJson(json));
            await createFormData(new Employee()).Execute(obj);
            var data = await repo.GetFormDataById(obj.Id);
            Assert.Equal(obj.Id, data.Id);
        }


    }
}
