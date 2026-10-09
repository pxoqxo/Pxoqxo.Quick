using System.Xml.Serialization;

namespace Pxoqxo.Quick
{
    public static class QuickXml
    {
        public static string? ToXml<T>(T model)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using StringWriter writer = new StringWriter();
                serializer.Serialize(writer, model);

                return writer.ToString();
            }
            catch
            {
                return null;
            }
        }
        public static T? FromXml<T>(string xml)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using StringReader reader = new StringReader(xml);
                return (T?)serializer.Deserialize(reader);
            }
            catch
            {
                return default;
            }
        }
    }
}
