using System;

namespace Domain.Entities
{
    public class TextFieldDefinition : FieldDefinition
    {
        internal TextFieldDefinition(Guid formDefinitionId, string fieldKey, string name, bool optional, int displayOrder)
            : base(formDefinitionId,fieldKey,name, optional, displayOrder) { }

        public override FieldType Type => FieldType.Text;
    }
}
