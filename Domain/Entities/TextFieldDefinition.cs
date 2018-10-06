using System;

namespace Domain.Entities
{
    public class TextFieldDefinition : FieldDefinition
    {
        public int? MinLength { get; protected set; }
        public int? MaxLength { get; protected set; }
        internal TextFieldDefinition(Guid formDefinitionId,
            string fieldKey,
            string name,
            int displayOrder,
            bool required)
            : base(formDefinitionId, fieldKey, name, displayOrder, required) { }

        public override FieldType Type => FieldType.Text;
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
        protected override Validator AdvancedValidator =>
            Validators.Combine(
                    Validators.MinLength(MinLength),
                    Validators.MinLength(MaxLength)
                    );
    }
}
