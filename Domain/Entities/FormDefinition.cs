using System;
using System.Collections.Generic;
namespace Domain
{
    public class FormDefinition 
    {
        public string Id { get; }
        public IEnumerable<FieldDefinition> FieldDefinitions { get; }
        public FormDefinition(IEnumerable<FieldDefinition> fieldDefinitions)
        {
            FieldDefinitions = fieldDefinitions ?? throw new ArgumentNullException(nameof(fieldDefinitions));
        }
        public FormDefinition(string id,IEnumerable<FieldDefinition> fieldDefinitions) : this(fieldDefinitions)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            this.Id = id;
        }
    }
}
