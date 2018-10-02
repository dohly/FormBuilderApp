using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Gateways
{
    public interface IMetadataRepository
    {
        Task<IEnumerable<FormDefinition>> GetFormTemplates();
        Task<IEnumerable<FieldDefinition>> GetFieldDefinitionsByFormId(string formTemplateId);
        Task<string> CreateFormDefinition(FormDefinition definition);
    }
}
