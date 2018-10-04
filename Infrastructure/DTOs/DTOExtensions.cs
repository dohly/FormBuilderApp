using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DTOs
{
    public static class DTOExtensions
    {
        public static FormDefinitionDTO ToDTO(this FormDefinition def)
            => new FormDefinitionDTO
            {
                Id = def.Id,
                Name = def.Name,
                Fields = def.FieldDefinitions.Select(fd => fd.ToDTO()).ToList()
            };
        public static FieldDefinitionDTO ToDTO(this FieldDefinition def)
            => new FieldDefinitionDTO
            {
                DisplayOrder = def.DisplayOrder,
                FieldKey = def.FieldKey,
                FieldName = def.FieldName,
                FormDefinitionId = def.FormDefinitionId,
                Optional = def.Optional,
                Type = def.Type
            };
    }
}
