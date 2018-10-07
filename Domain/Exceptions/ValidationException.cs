using System;

namespace Domain.Exceptions
{
    public class ValidationException:Exception
    {
        public ValidationException(ValidationError error)
        {
            Error = error;
        }

        public ValidationError Error { get; }
    }
}
