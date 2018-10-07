using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Gateways
{
    public interface IMetadataRepository
    {
        Task<IEnumerable<FormDefinition>> GetFormDefinitions();
        Task<IEnumerable<FieldDefinition>> GetFieldDefinitionsByFormId(Guid FormDefinitionId);
        Task CreateFormDefinition(FormDefinition definition);
        Task<FormDefinition> GetFormDefinitionById(Guid id);
    }
}
