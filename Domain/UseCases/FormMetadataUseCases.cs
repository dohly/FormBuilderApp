using Domain.Gateways;
using System;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class FormMetadataUseCases
    {
        private readonly IMetadataRepository repository;

        public FormMetadataUseCases(IMetadataRepository repository)
        {
            this.repository = repository;
        }
        public async Task<FormDefinition> GetFormDefinitionById(string id) =>
            new FormDefinition(id, await repository.GetFieldDefinitionsByFormId(id));
        public async Task<string> CreateNewFormDefinition(FormDefinition definition)
        {
            return await repository.CreateFormDefinition(definition);
        }
    }
}
