namespace Domain
{
    public class TextFieldDefinition : FieldDefinition
    {
        public TextFieldDefinition(string id, bool optional, int displayOrder)
            : base(id, optional, displayOrder) { }

        public override FieldType Type => FieldType.Text;
    }
}
