using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Domain.Entities
{
    public class SelectOption
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public class RadioButtonFieldDefinition : FieldDefinition
    {
        public RadioButtonFieldDefinition(string key, string name, IDictionary<string, string> avalableOptions, bool required=true)
            : base(key, name, required)
        {
            if (avalableOptions == null)
            {
                throw new System.ArgumentNullException(nameof(avalableOptions));
            }
            if (avalableOptions.Count < 2) throw new System.ArgumentException("Need at least 2 options", nameof(avalableOptions));
            AvalableOptions =avalableOptions.Select(x=>new SelectOption { Value = x.Key, Text = x.Value });
        }

        public override FieldType Type => FieldType.Radio;

        public IEnumerable<SelectOption> AvalableOptions { get; }

        public override ValidationError Validate(JToken serializedValue)
        {
            var validator = Validators.Combine(Required ? Validators.RequiredText : Validators.Empty,
                Validators.ShouldBeIn(AvalableOptions.Select(x=>x.Value)));
            return validator(FieldKey, serializedValue);
        }
    }
}
