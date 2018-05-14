
using System.Xml;
using System.Xml.Serialization;

namespace StaticCommons.Class.Inflector
{
    /**
     * Base
     * https://stackoverflow.com/questions/11447529/convert-an-object-to-an-xml-string
     */
    public static class Xml
    {
        public static string ToXml(this object obj)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(stringwriter, obj);
            return stringwriter.ToString();
        }

        public static string ToCleanXml(this object obj)
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(obj.GetType());
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            using (var stream = new System.IO.StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, obj, emptyNamepsaces);
                return stream.ToString();
            }
        }

        public static T ToObject<T>(string xmlText)
        {
            var stringReader = new System.IO.StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(T));
            return (T) serializer.Deserialize(stringReader);
        }
    }
}
