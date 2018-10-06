using Domain;
using Domain.Entities;
using Domain.Exceptions;
using Domain.UseCases;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class DataTests
    {
        private CreateNewFilledFormUseCase createForm(User caller) =>
            new CreateNewFilledFormUseCase(new DummyGuard(), caller);
        private FormDefinition sampleForm = new FormDefinition("User profile")
            .WithTextField(displayName: "First name", key: "FN", optional: false)
            .WithTextField(displayName: "Last name", key: "LN", optional: false);
        [Fact]
        public void CannotCreateFormValueIfRequiredValueIsEmpty()
            => Assert.Throws<ValidationException>(
                () => new FormObject(sampleForm, new Dictionary<string, string>{
                    { "FN","" }
                }));



    }
}
