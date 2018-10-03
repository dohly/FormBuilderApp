using Domain;
using Xunit;

namespace Tests
{
    public class ValidationTests
    {
        [Fact]
        public void MinLengthWorks()
        {
            var validator = Validators.MinLength(3);
            Assert.False(validator("12"));
            Assert.True(validator("123"));
            Assert.True(validator("1234"));
        }
        [Fact]
        public void MaxLengthWorks()
        {
            var validator = Validators.MaxLength(3);
            Assert.False(validator("1256"));
            Assert.True(validator("123"));
            Assert.True(validator("12"));
        }
        [Fact]
        public void CombineWorks()
        {
            var validator = Validators.Combine(Validators.MinLength(3), Validators.MaxLength(5));
            Assert.False(validator("12"));
            Assert.True(validator("123"));
            Assert.True(validator("1234"));
            Assert.True(validator("12345"));
            Assert.False(validator("123456"));
        }

    }
}
