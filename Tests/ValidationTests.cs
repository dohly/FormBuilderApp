using Domain;
using Newtonsoft.Json.Linq;
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
        [Fact]
        public void CheckTypeWorks()
        {
            Assert.Null(Validators.ShouldBeType(JTokenType.Boolean)("", true));
            Assert.Null(Validators.ShouldBeType(JTokenType.String)("", "blabla"));
            Assert.Null(Validators.ShouldBeType(JTokenType.Integer)("", 123));            
            Assert.NotNull(Validators.ShouldBeType(JTokenType.Boolean)("", 123));
            Assert.NotNull(Validators.ShouldBeType(JTokenType.Boolean)("", "true"));
        }
        [Fact]
        public void ShouldBeInWorks()
        {
            Assert.NotNull(Validators.ShouldBeIn(new[] {"a","b" })("", "c"));
            Assert.Null(Validators.ShouldBeIn(new[] { "a", "b" })("", "a"));
        }
    }
}
