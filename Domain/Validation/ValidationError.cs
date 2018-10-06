namespace Domain
{
    public class ValidationError
    {
        public ValidationError(string fieldKey, string description = "Invalid")
        {
            FieldKey = fieldKey;
            Description = description;
        }

        public string FieldKey { get; }
        public string Description { get; }
    }
}
