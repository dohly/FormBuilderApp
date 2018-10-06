using Domain.Entities;
using System;

namespace Infrastructure.DTOs
{
    public class FieldDefinitionDTO
    {
        public Guid FormDefinitionId { get; set; }
        public bool Required { get; set; }
        public string FieldKey { get; set; }
        public string FieldName { get; set; }
        public int DisplayOrder { get; set; }
        public FieldType Type { get; set; }
    }
}
