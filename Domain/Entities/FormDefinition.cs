using System;
using System.Collections.Generic;
namespace Domain
{
    public class FormDefinition : BaseEntity
    {
        public string Name { get; }
        public IEnumerable<FieldDefinition> FieldDefinitions { get; }
        public FormDefinition(string name, IEnumerable<FieldDefinition> fieldDefinitions)
        {
            Id = Guid.NewGuid();
            FieldDefinitions = fieldDefinitions;
            Name = name;
        }
        public FormDefinition(Guid id, string name, IEnumerable<FieldDefinition> fieldDefinitions) : this(name, fieldDefinitions)
        {
            this.Id = id;
        }
    }
}
