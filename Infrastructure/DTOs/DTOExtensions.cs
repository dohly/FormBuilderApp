using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTOs
{
    public static class DTOExtensions
    {
        public static FormDefinitionDTO ToDTO(this FormDefinition def)
            => new FormDefinitionDTO
            {
                Id = def.Id,
                Name = def.Name
            };
    }
}
