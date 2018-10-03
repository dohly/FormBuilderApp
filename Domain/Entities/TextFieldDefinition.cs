using System;

namespace Domain.Entities
{
    public class TextFieldDefinition : FieldDefinition
    {
        internal TextFieldDefinition(Guid formDefinitionId, string fieldKey, 
            string name, int displayOrder, bool optional, Validator validator)
            : base(formDefinitionId,fieldKey,name, displayOrder,optional, validator) { }

        public override FieldType Type => FieldType.Text;
    }
}
