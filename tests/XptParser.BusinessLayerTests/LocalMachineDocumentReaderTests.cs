using XptParser.BusinessLayer;
using System;
using System.Threading.Tasks;

namespace XptParser.BusinessLayerTests
{
    public sealed class LocalMachineDocumentReaderTests
    {
        private readonly LocalMachineDocumentReader reader = new();

        [Theory]
        [InlineData("", typeof(ArgumentException))]
        [InlineData(" ", typeof(ArgumentException))]
        [InlineData(null, typeof(ArgumentNullException))]
        public async Task ReadAsStreamAsync_WithIncorrectFilePath_ThrowsSuitableException(string fullPath, Type exceptionType)
        {
            var action = () => this.reader.ReadAsStreamAsync(fullPath);

            await Assert.ThrowsAsync(exceptionType, () => action());
        }

        [Theory]
        [InlineData("Data/testFile.txt")]
        public async Task ReadAsStreamAsync_WithCorrectFilePath_ReturnStream(string fullPath)
        {
            var stream = await this.reader.ReadAsStreamAsync(fullPath);

            Assert.NotNull(stream);
        }
    }
}