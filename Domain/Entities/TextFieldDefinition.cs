using System;

namespace Domain.Entities
{
    public class TextFieldDefinition : FieldDefinition
    {
        public TextFieldDefinition(Guid formDefinitionId, string fieldKey, bool optional, int displayOrder)
            : base(formDefinitionId,fieldKey, optional, displayOrder) { }

        public override FieldType Type => FieldType.Text;
    }
}
