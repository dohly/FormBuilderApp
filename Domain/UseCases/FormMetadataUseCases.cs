using Domain.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<string> CreateNewFormDefinition(FormDefinition form)
        {
            if (HasDuplicates(form.FieldDefinitions, x => x.FieldId))
            {
                throw new InvalidOperationException();
            }
            return await repository.CreateFormDefinition(form);
        }
        private bool HasDuplicates<T>(IEnumerable<T> items, Func<T, object> selector)
        {            
            var allValues=items.Select(selector);
            var withoutDuplicates = allValues.Distinct();
            return allValues.Count() != withoutDuplicates.Count();
        }
    }
}
