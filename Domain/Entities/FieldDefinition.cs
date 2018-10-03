
using System;
namespace Domain.Entities
{
    public abstract class FieldDefinition : BaseEntity
    {
        private Validator validator;

        public Guid FormDefinitionId { get; }
        public bool Optional { get; protected set; }
        public string FieldKey { get; protected set; }
        public string FieldName { get; protected set; }
        public int DisplayOrder { get; protected set; }
        public Validator IsValid =>
            (serializedValue) =>
                Optional && string.IsNullOrEmpty(serializedValue) ?
                        true
                        : validator(serializedValue);
        public abstract FieldType Type { get; }
        internal FieldDefinition(Guid formDefinitionId,
            string key,
            string name,
            int displayOrder,
            bool optional,
            Validator validator,
             Guid? id = null)
        {
            this.FormDefinitionId = formDefinitionId;
            FieldKey = key;
            this.validator = validator;
            FieldName = name;
            Optional = optional;
            DisplayOrder = displayOrder;
            Id = id ?? Guid.NewGuid();
        }
    }
}
