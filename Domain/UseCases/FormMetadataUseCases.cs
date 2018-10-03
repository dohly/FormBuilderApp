using Domain.Entities;
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
        private readonly ISecurityService guard;

        public FormMetadataUseCases(IMetadataRepository repository, ISecurityService guard)
        {
            this.repository = repository;
            this.guard = guard;
        }
        public async Task<FormDefinition> GetFormDefinition(User requester, Guid id)
        {
            if (!await guard.CanRetrieveFormDefinition(requester, id))
            {
                throw new System.UnauthorizedAccessException();
            }
            var form = await repository.GetFormDefinitionById(id);            
            return form;
        }
        public async Task CreateNewFormDefinition(User requester,FormDefinition form)
        {            
            if (!await guard.CanCreateNewForms(requester))
            {
                throw new System.UnauthorizedAccessException();
            }
            if (HasDuplicates(form.FieldDefinitions, x => x.FieldKey))
            {
                throw new InvalidOperationException();
            }
            await repository.CreateFormDefinition(form);
        }
        private bool HasDuplicates<T>(IEnumerable<T> items, Func<T, object> selector)
        {            
            var allValues=items.Select(selector);
            var withoutDuplicates = allValues.Distinct();
            return allValues.Count() != withoutDuplicates.Count();
        }
    }
}
