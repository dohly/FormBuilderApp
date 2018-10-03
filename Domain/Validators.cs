using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public delegate bool Validator(string serializedValue);
    public class Validators
    {
        public static Validator RequiredText => v => !string.IsNullOrWhiteSpace(v);
        public static Validator MinLength(int minlength) => v => !string.IsNullOrWhiteSpace(v) && v.Length >= minlength;
        public static Validator MaxLength(int maxlength) => v => !string.IsNullOrWhiteSpace(v) && v.Length <= maxlength;
        public static Validator Combine(params Validator[] validators) => v => validators.All(x => x(v));
    }
}
