using XptParser.BusinessLayer;
using XptParser.Contracts;

namespace XptParser.BusinessLayerTests
{
    public sealed class UpperNormalizerTests
    {
        private readonly INormalizer normalizer;

        public UpperNormalizerTests()
        {
            this.normalizer = new UpperNormalizer();
        }

        [Theory]
        [InlineData("test", "TEST")]
        [InlineData("not", "NOT")]
        [InlineData("aspNeT", "ASPNET")]
        public void Normalize_WithInputStrings_ReturnsNormalizerToUpperStrings(string input, string expectedOutput)
        {
            var actualOutput = this.normalizer.Normalize(input);

            Assert.NotNull(actualOutput);
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}