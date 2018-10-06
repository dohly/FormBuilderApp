using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class FormDefinition : BaseEntity
    {
        private Dictionary<string, FieldDefinition> fields = new Dictionary<string, FieldDefinition>();

        public string Name { get; }
        public string Description { get; }
        public IEnumerable<FieldDefinition> FieldDefinitions => fields.Values;
        public FieldDefinition this[string fieldKey] => fields[fieldKey];
        public Guid? NextVersionId { get; }
        public FormDefinition(string name, string description = null)
        {
            Id = Guid.NewGuid();
            Name = string.IsNullOrEmpty(name) ?
                throw new ArgumentException("Can't be empty", nameof(name)) : name;
            Description = description;
        }
        public FormDefinition(Guid id, string name, string description) : this(name, description)
        {
            this.Id = id;
        }
        public FormDefinition WithTextField(Func<TextFieldDefinition> builder)
        {
            var textDef = builder();
            textDef.SetFormDefinitionId(this.Id);
            textDef.SetDisplayOrder(this.fields.Count);
            this.AddNewField(textDef);
            return this;
        }
        private void AddNewField(FieldDefinition def)
        {
            if (fields.ContainsKey(def.FieldKey)
                || FieldDefinitions.Any(x => x.FieldName == def.FieldName))
            {
                throw new InvalidOperationException("Can't add duplicate field");
            }
            this.fields[def.FieldKey] = def;
        }
    }
}
