using System;
using Newtonsoft.Json.Linq;

namespace Domain.Entities
{
    public class TextFieldDefinition : FieldDefinition
    {
        public override FieldType Type => FieldType.Text;
        public int? MinLength { get; protected set; }
        public int? MaxLength { get; protected set; }
        public TextFieldDefinition(
            string fieldKey,
            string name,
            bool required)
            : base(fieldKey, name, required) { }

        public TextFieldDefinition Max(int max)
        {
            int? minValidValue = 0;
            if (MinLength > minValidValue) minValidValue = MinLength;
            if (max < minValidValue) throw new ArgumentOutOfRangeException(nameof(max), $"should be greater than {minValidValue}");
            this.MaxLength = max;
            return this;
        }
        public TextFieldDefinition Min(int min)
        {
            if (min > MaxLength) throw new ArgumentOutOfRangeException(nameof(min), $"should be less than {MaxLength}");
            if (min < 0) throw new ArgumentOutOfRangeException(nameof(min), "should be greater than 0");
            this.MinLength = min;
            return this;
        }

        public override ValidationError Validate(JToken serializedValue)
        {
            var validation = Required ?
               Validators.Combine(Validators.RequiredText, AdvancedValidator)
               : AdvancedValidator;
            return validation(FieldKey, serializedValue);
        }

        private Validator AdvancedValidator =>
            Validators.Combine(
                    Validators.MinLength(MinLength),
                    Validators.MaxLength(MaxLength)
                    );
    }
}
