
using System;
namespace Domain
{
    public abstract class FieldDefinition
    {
        public bool Optional { get; protected set; }
        public string FieldId { get; protected set; }
        public int DisplayOrder { get; protected set; }
        public abstract FieldType Type { get; }
        public FieldDefinition(string id, bool optional, int displayOrder)
        {
            FieldId = id;
            Optional = optional;
            DisplayOrder = displayOrder;
        }
    }
}
