using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Gateways
{
    public interface IFormDataRepository
    {
        Task SaveForm(FormObject filledForm);
        Task<FormObject> GetFormDataById(Guid id);
        Task<IEnumerable<FormObject>> GetObjectsByFormId(Guid formDefinitionId);
    }
}
