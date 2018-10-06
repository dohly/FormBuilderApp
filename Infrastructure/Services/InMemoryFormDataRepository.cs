using Domain.Entities;
using Domain.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryFormDataRepository : IFormDataRepository
    {
        private List<FormObject> store = new List<FormObject>();

        public Task<FormObject> GetFormDataById(Guid id)
            => Task.FromResult(store.FirstOrDefault(x => x.Id == id));

        public Task<IEnumerable<FormObject>> GetObjectsByFormId(Guid formDefinitionId)
            => Task.FromResult(store.Where(x => x.FormDefinitionId == formDefinitionId));

        public async Task SaveForm(FormObject filledForm)
        {
            store.Add(filledForm);
        }
    }
}
