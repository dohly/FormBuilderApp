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
        private CreateNewFilledForm createFormData(User caller) =>
            new CreateNewFilledForm(new DummyGuard(), repo, caller);
        private FormDefinition sampleForm =
            new FormDefinition("User profile")
            .AddField(() => new TextFieldDefinition(name: "First name", fieldKey: "FN", required: true))
            .AddField(() => new TextFieldDefinition(name: "Last name", fieldKey: "LN", required: true))
            .AddField(() => new TextFieldDefinition("MIN_MAX_OPT", "From 2 to 5 optional", false).Min(2).Max(3));



        [Fact]
        public void CannotCreateFormObjectIfRequiredValueIsEmpty()
            => Assert.Throws<ValidationException>(
                () => new FormObject(sampleForm, fromJson("{'FN':''}")));
        [Fact]
        public void CannotCreateFormObjectIfNoValuesReceived()
            => Assert.Throws<ValidationException>(
                () => new FormObject(sampleForm, fromJson("{}")));
        [Fact]
        public void CannotCreateFormObjectIfSomeValueTooLong()
        {
            var testForm = new FormDefinition("test")
                    .AddField(() =>
                    new TextFieldDefinition("MAX", "Max length test", false)
                    .Max(5));
            Assert.Throws<ValidationException>(
               () => new FormObject(testForm
                   , fromJson("{'MAX':'1234567'}")));
        }
        [Fact]
        public void CannotCreateFormObjectIfSomeValueTooShort()
        {
            var testForm = new FormDefinition("test")
                    .AddField(() =>
                    new TextFieldDefinition("MIN", "Min length test", false)
                    .Min(5));
            Assert.Throws<ValidationException>(
               () => new FormObject(testForm
                   , fromJson("{'MIN':'123'}")));
        }
        [Fact]
        public void CanCreateFormObjectIfValuesAreValid()
            => Assert.NotNull(new FormObject(sampleForm,
                fromJson("{ 'FN':'first name' ,'LN':'last name' }")));
        [Fact]
        public async Task FullSuccessExample()
        {
            string json = "{ 'FN':'first name' ,'LN':'last name', 'MIN_MAX_OPT':'' }";
            var obj = new FormObject(sampleForm, fromJson(json));
            await createFormData(new Employee()).Execute(obj);
            var data = await repo.GetFormDataById(obj.Id);
            Assert.Equal(obj.Id, data.Id);
        }


    }
}
