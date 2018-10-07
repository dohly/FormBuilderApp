using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.DTOs
{
    public class FormDefinitionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ObjectsCount { get; set; }
        public IEnumerable<FieldDefinition> Fields { get; set; }
    }
}
