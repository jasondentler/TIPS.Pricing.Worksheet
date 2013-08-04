using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TIPS.Pricing.UI.Wireup
{
    public class JsonNetFormatter : MediaTypeFormatter 
    {
        private readonly JsonSerializerSettings _settings;
        private readonly Encoding _encoding;

        public JsonNetFormatter() : this(null)
        {
        }

        public JsonNetFormatter(JsonSerializerSettings settings)
        {
            _settings = settings ?? new JsonSerializerSettings();
            _encoding = new UTF8Encoding(false, true);
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            SupportedEncodings.Add(_encoding);
        }

        public override bool CanReadType(Type type)
        {
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var serializer = JsonSerializer.Create(_settings);
            return Task.Factory.StartNew(() =>
                {
                    using (var streamReader = new StreamReader(readStream, _encoding))
                    using (var jsonReader = new JsonTextReader(streamReader))
                        return serializer.Deserialize(jsonReader);
                });
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, System.Net.TransportContext transportContext)
        {
            var serializer = JsonSerializer.Create(_settings);
            return Task.Factory.StartNew(() =>
                {
                    using (var streamWriter = new StreamWriter(writeStream, _encoding))
                    using (var jsonWriter = new JsonTextWriter(streamWriter) {CloseOutput = true})
                    {
                        serializer.Serialize(jsonWriter, value);
                        jsonWriter.Flush();
                    }
                });
        }


    }
}
