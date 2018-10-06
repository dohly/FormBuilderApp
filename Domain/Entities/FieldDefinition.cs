
using System;
namespace Domain.Entities
{
    public abstract class FieldDefinition : BaseEntity
    {
        protected virtual Validator AdvancedValidator { get; } = (k, v) => null;

        public Guid FormDefinitionId { get; }
        public bool Required { get; protected set; }
        public string FieldKey { get; protected set; }
        public string FieldName { get; protected set; }
        public int DisplayOrder { get; protected set; }
        public ValidationError Validate(string serializedValue)
        {
            var validation= Required ? 
                Validators.Combine(Validators.RequiredText, AdvancedValidator)
                :AdvancedValidator;
            return validation(FieldKey, serializedValue);
        }
        public abstract FieldType Type { get; }
        protected FieldDefinition(Guid formDefinitionId,
            string key,
            string name,
            int displayOrder,
            bool required,
             Guid? id = null)
        {
            this.FormDefinitionId = formDefinitionId;
            FieldKey = key;
            FieldName = name;
            Required = required;
            DisplayOrder = displayOrder;
            Id = id ?? Guid.NewGuid();
        }
    }
}
