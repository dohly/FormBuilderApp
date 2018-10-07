using Newtonsoft.Json.Linq;
using System;

namespace Domain.Entities
{
    public class DateFieldDefinition : FieldDefinition
    {
        public DateFieldDefinition(string key, string name, bool required) : base(key, name, required)
        {
        }

        public override FieldType Type => FieldType.Date;

        public override ValidationError Validate(JToken serializedValue)
        {
            var validator1 = string.IsNullOrEmpty(serializedValue.Value<string>()) ?
               Validators.Empty
               : (k, v) => DateTime.TryParse(v.Value<string>(), out _) ? null : new ValidationError(FieldKey, "is not date");
            var validator2 = Required ? Validators.RequiredText : Validators.Empty;
            return Validators.Combine(validator1, validator2)(FieldKey, serializedValue);
        }
    }
}
