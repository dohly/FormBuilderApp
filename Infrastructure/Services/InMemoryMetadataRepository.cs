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
        // Just for demo & test purposes
        public static FormDefinition DummyForm => new FormDefinition(
            Guid.Parse("d1615e0e-271f-4341-873c-faf77e3728cc"),
                "Dummy Form", "Lorem ipsum dolor " +
                "sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                                "fugiat nulla pariatur. ")
            .AddField(() => new TextFieldDefinition("FN", "First name", true).Min(2))
            .AddField(() => new TextFieldDefinition("LN", "Last name", true))
            .AddField(() => new TextFieldDefinition("MN", "Middle name", false).Max(3));

        private List<FormDefinition> formTemplatesTable = new List<FormDefinition>() {
            DummyForm,

            new FormDefinition("Validations demo form","Let's check all possible field types and validations")
            .AddField(()=> new TextFieldDefinition("MAX","Max 5 required", true).Max(5))
            .AddField(()=> new TextFieldDefinition("MIN","Min 5 required", true).Min(5))
            .AddField(()=> new TextFieldDefinition("MIN_MAX","From 2 to 5 required", true).Min(2).Max(5))
            .AddField(()=> new TextFieldDefinition("MIN_MAX_OPT","From 2 to 5 optional", false).Min(2).Max(3))
            .AddField(()=>new CheckboxFieldDefinition("BOOL", "Required bool", true))
            .AddField(()=>new CheckboxFieldDefinition("BOOL_OP", "Optional bool", false))
            .AddField(()=>new RadioButtonFieldDefinition("RB","Radio",
                new Dictionary<string,string> {
                    { "id1","Choice1"},
                    {"id2","Choice2" }
                }))
             .AddField(()=>new DropdownFieldDefinition("DDR","Mandatory Dropdown",
                new Dictionary<string,string> {
                    { "id1","option 1"},
                    {"id2","option 2" }
                }, true))
        //.WithCheckBox(()=>new C,
   
    };
    public async Task CreateFormDefinition(FormDefinition definition)
    {
        formTemplatesTable.Add(definition);
    }

    public Task<IEnumerable<FieldDefinition>> GetFieldDefinitionsByFormId(Guid formDefinitionId)
        => Task.FromResult(this.formTemplatesTable.Single(x => x.Id == formDefinitionId).FieldDefinitions);

    public Task<FormDefinition> GetFormDefinitionById(Guid id) =>
        Task.FromResult(formTemplatesTable.FirstOrDefault(x => x.Id == id));

    public Task<IEnumerable<FormDefinition>> GetFormDefinitions() => Task.FromResult(this.formTemplatesTable.AsEnumerable());

}
}
