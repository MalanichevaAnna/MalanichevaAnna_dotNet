using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;


namespace LR_1.DL.ReaderWriter.Writer
{
    public class JsonWriter : IWriter
    {
        public void Write(StudentAndSummaryMarkInfo information, string path)
        {
            if (information == null || string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException();
            }
               
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

            string serializedCollection = JsonSerializer.Serialize(information, options);

            using var writer = new StreamWriter(path);
            writer.Write(serializedCollection);
        }
    }
}
