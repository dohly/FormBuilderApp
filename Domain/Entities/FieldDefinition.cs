
using Newtonsoft.Json.Linq;
using System;
namespace Domain.Entities
{
    public abstract class FieldDefinition : BaseEntity
    {
        protected abstract Validator AdvancedValidator { get; }

        public Guid FormDefinitionId { get; private set; }
        public bool Required { get; protected set; }
        public string FieldKey { get; protected set; }
        public string FieldName { get; protected set; }
        public int DisplayOrder { get; protected set; }
        public ValidationError Validate(JToken serializedValue)
        {
            var validation= Required ? 
                Validators.Combine(Validators.RequiredText, AdvancedValidator)
                :AdvancedValidator;
            return validation(FieldKey, serializedValue);
        }
        public abstract FieldType Type { get; }
        protected FieldDefinition(string key,
            string name,
            bool required)
        {
            FieldKey = key;
            FieldName = name;
            Required = required;
            Id = Guid.NewGuid();
        }
        internal void SetFormDefinitionId(Guid id)
        {
            this.FormDefinitionId = id;
        }
        internal void SetDisplayOrder(int order)
        {
            this.DisplayOrder = order;
        }
    }
}
