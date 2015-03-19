using System.Linq;

namespace NBatch.Core.Reader.FileReader
{
    sealed class DelimitedLineTokenizer : ILineTokenizer
    {
        private readonly char _token;
        public const char DEFAULT_TOKEN = ',';

        public DelimitedLineTokenizer(string[] headers, char token = DEFAULT_TOKEN)
        {
            _token = token;
            Headers = headers ?? Enumerable.Empty<string>().ToArray();
        }

        public FieldSet Tokenize(string line)
        {
            string[] rowItems = line.Split(_token);
            return FieldSet.Create(Headers, rowItems);
        }

        public string[] Headers { get; private set; }
    }
}