using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTOs
{
    public class FormDefinitionDTO
    {
        public Guid Id { get; internal set; }
        public string Name { get; internal set; }
    }
}
