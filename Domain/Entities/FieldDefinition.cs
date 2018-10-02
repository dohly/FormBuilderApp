
using System;
namespace Domain
{
    public abstract class FieldDefinition:BaseEntity
    {
        public bool Optional { get; protected set; }
        public string FieldKey { get; protected set; }
        public int DisplayOrder { get; protected set; }
        public abstract FieldType Type { get; }
        public FieldDefinition(string key, bool optional, int displayOrder, Guid? id=null)
        {
            FieldKey = key;
            Optional = optional;
            DisplayOrder = displayOrder;
            Id = id ?? Guid.NewGuid();
        }
    }
}
