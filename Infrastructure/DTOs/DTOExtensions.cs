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
                ObjectsCount = def.ObjectsCount,
                Fields = def.FieldDefinitions //.Select(fd => fd.ToDTO()).ToList()
            };

    }
}
