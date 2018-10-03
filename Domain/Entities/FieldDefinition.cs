
using System;
namespace Domain.Entities
{
    public abstract class FieldDefinition : BaseEntity
    {
        public Guid FormDefinitionId { get; }
        public bool Optional { get; protected set; }
        public string FieldKey { get; protected set; }
        public string FieldName { get; protected set; }
        public int DisplayOrder { get; protected set; }
        public abstract FieldType Type { get; }
        internal FieldDefinition(Guid formDefinitionId, string key, string name, bool optional, int displayOrder, Guid? id = null)
        {
            this.FormDefinitionId = formDefinitionId;
            FieldKey = key;
            FieldName = name;
            Optional = optional;
            DisplayOrder = displayOrder;
            Id = id ?? Guid.NewGuid();
        }
    }
}
