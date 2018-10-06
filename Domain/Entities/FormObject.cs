using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain.Entities
{
    public class FormObject : BaseEntity
    {
        private Dictionary<string, string> values = new Dictionary<string, string>();
        public Guid FormDefinitionId { get; }
        public IReadOnlyDictionary<string, string> Values =>
            new ReadOnlyDictionary<string, string>(values);
        public FormObject(FormDefinition metadata, IDictionary<string, string> values)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException(nameof(metadata));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            this.FormDefinitionId = metadata.Id;
            foreach (var valuePair in values)
            {
                var fieldDefition = metadata[valuePair.Key];
                // Let's ignore additional unknown values. Don't throw exceptions
                if (fieldDefition == null) continue;
                var validatedValue = fieldDefition.IsValid(valuePair.Value) ?
                                    valuePair.Value : throw new ValidationException(valuePair.Key);
                this.values.Add(valuePair.Key, validatedValue);
            }
        }
    }
}
