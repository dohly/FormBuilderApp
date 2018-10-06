using Domain.Entities;
using System;

namespace Infrastructure.DTOs
{
    public abstract class FieldDefinitionDTO
    {
        public Guid FormDefinitionId { get; set; }
        public bool Required { get; set; }
        public string FieldKey { get; set; }
        public string FieldName { get; set; }
        public int DisplayOrder { get; set; }
        public FieldType Type { get; set; }
        public FieldDefinitionDTO(FieldDefinition def)
        {
            FieldKey = def.FieldKey;
            DisplayOrder = def.DisplayOrder;
            FieldName = def.FieldName;
            FormDefinitionId = def.FormDefinitionId;
            Required = def.Required;
            Type = def.Type;
        }
    }

}
