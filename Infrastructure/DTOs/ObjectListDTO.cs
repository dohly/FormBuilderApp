using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Infrastructure.DTOs
{
    public class ObjectListDTO
    {
        public IEnumerable<JObject> Objects { get; set; }
        public FormDefinitionDTO FormDefinition { get; set; }
    }
}
