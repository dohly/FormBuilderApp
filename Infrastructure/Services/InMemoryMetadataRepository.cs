using Domain;
using Domain.Entities;
using Domain.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryMetadataRepository : IMetadataRepository
    {
        // Just for demo & test purposes
        public static FormDefinition DummyForm => new FormDefinition(
            Guid.Parse("d1615e0e-271f-4341-873c-faf77e3728cc"),
                "Dummy Form", "Lorem ipsum dolor " +
                "sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam," +
                " quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." +
                " Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu " +
                "fugiat nulla pariatur. ")
            .WithTextField("FN", "First name", false)
            .WithTextField("LN", "Last name", false)
            .WithTextField("MN", "Middle name", true);

        private List<FormDefinition> formTemplatesTable = new List<FormDefinition>() {
            DummyForm
        };
        public async Task CreateFormDefinition(FormDefinition definition)
        {
            formTemplatesTable.Add(definition);
        }

        public Task<IEnumerable<FieldDefinition>> GetFieldDefinitionsByFormId(Guid formDefinitionId)
            =>Task.FromResult(this.formTemplatesTable.Single(x=>x.Id== formDefinitionId).FieldDefinitions);

        public Task<FormDefinition> GetFormDefinitionById(Guid id) =>
            Task.FromResult(formTemplatesTable.FirstOrDefault(x=>x.Id==id));

        public Task<IEnumerable<FormDefinition>> GetFormDefinitions() => Task.FromResult(this.formTemplatesTable.AsEnumerable());
        
    }
}
