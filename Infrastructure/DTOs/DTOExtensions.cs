using Domain.Entities;

namespace Infrastructure.DTOs
{
    public static class DTOExtensions
    {
        public static FormDefinitionDTO ToDTO(this FormDefinition def)
            => new FormDefinitionDTO
            {
                Id = def.Id,
                Name = def.Name,
                Description = def.Description,
                ObjectsCount=def.ObjectsCount,
                Fields = def.FieldDefinitions //.Select(fd => fd.ToDTO()).ToList()
            };
        public static FieldDefinitionDTO ToDTO(this FieldDefinition def)
        {
            FieldDefinitionDTO result=null;
            switch (def)
            {
                case TextFieldDefinition td:
                    result = new TextFieldDefinitionDTO(td);
                    break;
                //case FieldType.Dropdown:
                //    throw new NotImplementedException();
                //    break;
                //case FieldType.Date:
                //    throw new NotImplementedException();
                //    break;
                //case FieldType.Radio:
                //    throw new NotImplementedException();
                //    break;
                //case FieldType.Checkbox:
                //    throw new NotImplementedException();
                //    break;
                //case FieldType.Number:
                //    throw new NotImplementedException();
                //    break;
                //default:
                //    break;
            }
            
            return result;
        }
}
}
