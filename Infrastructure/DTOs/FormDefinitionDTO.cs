using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTOs
{
    public class FormDefinitionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<FieldDefinitionDTO> Fields { get; set; }
    }
}
