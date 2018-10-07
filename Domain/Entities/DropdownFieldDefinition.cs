using System.Collections.Generic;

namespace Domain.Entities
{
    public class DropdownFieldDefinition : SingleChoiceFieldDefinition
    {
        public DropdownFieldDefinition(string key, string name, IDictionary<string, string> avalableOptions, bool required ) : base(key, name, avalableOptions, required)
        {
        }

        public override FieldType Type => FieldType.Dropdown;
    }
}
