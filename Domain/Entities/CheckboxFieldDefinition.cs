using Newtonsoft.Json.Linq;

namespace Domain.Entities
{
    public class CheckboxFieldDefinition : FieldDefinition
    {
        public override FieldType Type => FieldType.Checkbox;

        public CheckboxFieldDefinition(
            string fieldKey,
            string name,
            bool required)
            : base(fieldKey, name, required) { }

        public override ValidationError Validate(JToken serializedValue)
        {
            var notBoolean = string.IsNullOrEmpty(serializedValue?.Value<string>()) ?
                Validators.Empty(FieldKey, serializedValue)
                : Validators.ShouldBeType(JTokenType.Boolean)(FieldKey, serializedValue);
            if (notBoolean != null) return notBoolean;
            if (Required && !serializedValue.Value<bool>())
            {
                return new ValidationError(FieldKey, "Required");
            }
            return null;
        }
    }
}
