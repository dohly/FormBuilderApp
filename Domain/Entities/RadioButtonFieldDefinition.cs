using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain.Entities
{
    public class RadioButtonFieldDefinition : SingleChoiceFieldDefinition
    {
        public RadioButtonFieldDefinition(string key, string name, IDictionary<string, string> avalableOptions, bool required = true) : base(key, name, avalableOptions, required)
        {
        }

        public override FieldType Type => FieldType.Radio;
    }
}
