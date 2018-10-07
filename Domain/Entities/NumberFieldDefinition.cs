using Newtonsoft.Json.Linq;
using System;

namespace Domain.Entities
{
    public class NumberFieldDefinition : FieldDefinition
    {
        public int? Min { get; private set; }
        public int? Max { get; private set; }
        public NumberFieldDefinition(string key, string name, bool required) : base(key, name, required)
        {
        }
        public NumberFieldDefinition LessThan(int max)
        {
            int? minValidValue = 0;
            if (Min > minValidValue) minValidValue = Min;
            if (max < minValidValue) throw new ArgumentOutOfRangeException(nameof(max), $"should be greater than {minValidValue}");
            this.Max = max;
            return this;
        }
        public NumberFieldDefinition GreaterThan(int min)
        {
            if (min > Max) throw new ArgumentOutOfRangeException(nameof(min), $"should be less than {Max}");
            if (min < 0) throw new ArgumentOutOfRangeException(nameof(min), "should be greater than 0");
            this.Min = min;
            return this;
        }
        public override FieldType Type => FieldType.Number;

        public override ValidationError Validate(JToken serializedValue)
        {
            var validator1 = string.IsNullOrEmpty(serializedValue.Value<string>()) ?
                Validators.Empty
                : (k, v) => int.TryParse(v.Value<string>(), out _) ? null : new ValidationError(FieldKey, "is NAN");
            var validator2 = Required ? Validators.RequiredText : Validators.Empty;
            return Validators.Combine(validator1, validator2)(FieldKey, serializedValue);
        }
    }
}
