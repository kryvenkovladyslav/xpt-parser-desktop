using XptParser.Contracts;
using XptParser.Domain;
using System;
using System.IO;
using System.Threading.Tasks;
using SasXptParser.Abstract;

namespace XptParser.BusinessLayer
{
    public class XptDocumentParser : IXptDocumentParser
    {
        protected ISasXptParsingProcessor Processor { get; private init; }

        public XptDocumentParser(ISasXptParsingProcessor processor)
        {
            this.Processor = processor ?? throw new ArgumentNullException(nameof(processor));
        }

        public virtual async Task<XptDocument> ParseAsync(Stream documentStream)
        {
            ArgumentNullException.ThrowIfNull(documentStream, nameof(documentStream));

            var parsedDocument = await this.ParseDocumentAsync(documentStream);

            return parsedDocument.ToXptDocument();
        }

        private Task<SasXptDocument> ParseDocumentAsync(Stream documentStream)
        {
            return Task.Run(() => this.Processor.ParseDocument(documentStream));
        }
    }
}