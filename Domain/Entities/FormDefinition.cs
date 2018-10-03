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
        public Guid? NextVersionId { get; }
        public FormDefinition(string name)
        {
            Id = Guid.NewGuid();
            Name = string.IsNullOrEmpty(name) ? 
                throw new ArgumentException("Can't be empty",nameof(name)) : name;
        }
        public FormDefinition(Guid id, string name) : this(name)
        {
            this.Id = id;
        }
    }
}
