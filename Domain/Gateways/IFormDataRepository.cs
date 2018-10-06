using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Gateways
{
    public interface IFormDataRepository
    {
        Task SaveForm(FormObject filledForm);
        Task<FormObject> GetFormDataById(Guid id);
    }
}
