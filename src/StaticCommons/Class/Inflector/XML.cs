
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

        public static T ToObject<T>(string xmlText)
        {
            var stringReader = new System.IO.StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(T));
            return (T) serializer.Deserialize(stringReader);
        }
    }
}
