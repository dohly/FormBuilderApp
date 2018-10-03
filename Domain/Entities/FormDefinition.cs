using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class FormDefinition : BaseEntity
    {
        private List<FieldDefinition> fields = new List<FieldDefinition>();

        public string Name { get; }
        public IEnumerable<FieldDefinition> FieldDefinitions => fields;
        public FieldDefinition this[string fieldKey] =>
            this.FieldDefinitions.FirstOrDefault(x => x.FieldKey == fieldKey);
        public Guid? NextVersionId { get; }
        public FormDefinition(string name)
        {
            Id = Guid.NewGuid();
            Name = string.IsNullOrEmpty(name) ?
                throw new ArgumentException("Can't be empty", nameof(name)) : name;
        }
        public FormDefinition(Guid id, string name) : this(name)
        {
            this.Id = id;
        }
        public FormDefinition WithTextField(string key, string displayName, bool optional, Validator validator=null)
        {
            if (fields.Any(x => x.FieldKey == key || x.FieldName == displayName))
            {
                throw new InvalidOperationException("Can't add duplicate field");
            }
            this.fields.Add(new TextFieldDefinition(this.Id, key, displayName, this.fields.Count, optional, validator));
            return this;
        }
    }
}
