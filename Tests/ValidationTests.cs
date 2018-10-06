using Domain;
using Xunit;

namespace Tests
{
    public class ValidationTests
    {
        string fieldKey = "FK";
        [Fact]
        public void MinLengthWorks()
        {
            var validator = Validators.MinLength(3);
            Assert.NotNull(validator(fieldKey,"12"));
            Assert.Null(validator(fieldKey, "123"));
            Assert.Null(validator(fieldKey, "1234"));
        }
        [Fact]
        public void MaxLengthWorks()
        {
            var validator = Validators.MaxLength(3);
            Assert.NotNull(validator(fieldKey,"1256"));
            Assert.Null(validator(fieldKey,"123"));
            Assert.Null(validator(fieldKey,"12"));
        }
        [Fact]
        public void CombineWorks()
        {
            var validator = Validators.Combine(Validators.MinLength(3), Validators.MaxLength(5));
            Assert.NotNull(validator(fieldKey,"12"));
            Assert.Null(validator(fieldKey,"123"));
            Assert.Null(validator(fieldKey,"1234"));
            Assert.Null(validator(fieldKey,"12345"));
            Assert.NotNull(validator(fieldKey,"123456"));
        }

    }
}
