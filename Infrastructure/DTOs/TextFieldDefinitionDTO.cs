using Domain.Entities;

namespace Infrastructure.DTOs
{
    public class TextFieldDefinitionDTO : FieldDefinitionDTO
    {
        public TextFieldDefinitionDTO(TextFieldDefinition td):base(td)
        {
            this.MinLength = td.MinLength;
            this.MaxLength = td.MaxLength;
        }

        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
    }

}
