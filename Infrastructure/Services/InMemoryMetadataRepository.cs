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
        private List<FormDefinition> formTemplatesTable = new List<FormDefinition>() {
            new FormDefinition("Dummy Form").WithTextField("FN","First name", true)
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
