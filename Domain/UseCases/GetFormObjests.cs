namespace Domain.UseCases
{
    using Domain.Entities;
    using Domain.Gateways;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GetFormObjests
    {
        private readonly ISecurityService guard;
        private readonly IFormDataRepository data;
        private readonly User caller;

        public GetFormObjests(ISecurityService guard, IFormDataRepository data, User caller)
        {
            this.guard = guard ?? throw new ArgumentNullException(nameof(guard));
            this.data = data ?? throw new ArgumentNullException(nameof(data));
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
        }
        public async Task<IEnumerable<FormObject>> Execute(Guid formDefinitionId)
        {
            if (!await guard.CanRetrieveFormObjects(formDefinitionId, caller))
            {
                throw new UnauthorizedAccessException();
            }
            return await data.GetObjectsByFormId(formDefinitionId);
        }
    }
}
