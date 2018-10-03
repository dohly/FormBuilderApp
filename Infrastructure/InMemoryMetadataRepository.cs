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
        private List<FormDefinition> formTemplatesTable = new List<FormDefinition>();
        private List<FieldDefinition> fieldsTable = new List<FieldDefinition>();
        public async Task CreateFormDefinition(FormDefinition definition)
        {
            formTemplatesTable.Add(definition);
            fieldsTable.AddRange(definition.FieldDefinitions);
        }

        public Task<IEnumerable<FieldDefinition>> GetFieldDefinitionsByFormId(Guid formDefinitionId)
            =>Task.FromResult(this.fieldsTable.Where(x=>x.FormDefinitionId== formDefinitionId));

        public Task<FormDefinition> GetFormDefinitionById(Guid id) =>
            Task.FromResult(formTemplatesTable.FirstOrDefault(x=>x.Id==id));

        public Task<IEnumerable<FormDefinition>> GetFormTemplates()
        {
            throw new NotImplementedException();
        }
    }
}
