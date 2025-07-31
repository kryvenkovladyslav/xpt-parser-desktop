using XptParser.Contracts;
using XptParser.Domain;
using System;
using System.IO;
using System.Threading.Tasks;
using SasXptParser.Abstract;

namespace XptParser.BusinessLayer
{
    /// <summary>
    /// Provides functionality to parse SAS XPT documents into <see cref="XptDocument"/> domain models
    /// </summary>
    public class XptDocumentParser : IXptDocumentParser
    {
        /// <summary>
        /// Gets the parsing processor used to parse the raw SAS XPT document
        /// </summary>
        protected ISasXptParsingProcessor Processor { get; private init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XptDocumentParser"/> class
        /// </summary>
        /// <param name="processor">The SAS XPT parsing processor</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="processor"/> is <c>null</c></exception>
        public XptDocumentParser(ISasXptParsingProcessor processor)
        {
            this.Processor = processor ?? throw new ArgumentNullException(nameof(processor));
        }

        /// <summary>
        /// Asynchronously parses a stream containing a SAS XPT document and returns a structured <see cref="XptDocument"/>
        /// </summary>
        /// <param name="documentStream">The input stream containing the SAS XPT data</param>
        /// <returns>A task that represents the asynchronous parsing operation. The result contains the parsed <see cref="XptDocument"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="documentStream"/> is <c>null</c></exception>
        public virtual async Task<XptDocument> ParseAsync(Stream documentStream)
        {
            ArgumentNullException.ThrowIfNull(documentStream, nameof(documentStream));

            var parsedDocument = await this.ParseDocumentAsync(documentStream);

            return parsedDocument.ToXptDocument();
        }

        /// <summary>
        /// Parses the raw SAS XPT document stream using the underlying processor
        /// </summary>
        /// <param name="documentStream">The input stream containing the SAS XPT data</param>
        /// <returns>A task that returns the parsed <see cref="SasXptDocument"/></returns>
        private Task<SasXptDocument> ParseDocumentAsync(Stream documentStream)
        {
            return Task.Run(() => this.Processor.ParseDocument(documentStream));
        }
    }
}