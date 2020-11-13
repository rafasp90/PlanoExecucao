using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Utils
{
    public class SerializacaoXml
    {
        public static string Serializar<T>(T value, string sRootName = "Xml", bool bRemoveDeclaration = true, bool bRemoveNameSpace = true) where T: class
        {            
            XmlWriterSettings oXmlWriterSettings = new XmlWriterSettings();
            XmlSerializerNamespaces oXmlSerializerNamespaces = null;
            XmlRootAttribute oXmlRootAttribute = null;

            if (string.IsNullOrEmpty(sRootName))
                oXmlRootAttribute = new XmlRootAttribute(sRootName);
            
            if (bRemoveDeclaration)            
                oXmlWriterSettings.OmitXmlDeclaration = true;
            
            if (bRemoveNameSpace)
            {
                oXmlSerializerNamespaces = new XmlSerializerNamespaces();
                oXmlSerializerNamespaces.Add("", "");
            }

            using(StringWriter oStringWriter = new StringWriter())
            {
                using(XmlWriter oXmlWriter = XmlWriter.Create(oStringWriter, oXmlWriterSettings))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T), oXmlRootAttribute);
                    xs.Serialize(oXmlWriter, value, oXmlSerializerNamespaces);
                    return oStringWriter.ToString();
                }
            }
        }

        public static T Desserializar<T>(string sXml) where T: class
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));

            using (XmlReader reader = XmlReader.Create(new StringReader(sXml)))
            {
                return (T)xs.Deserialize(reader);
            }
        }

    }
}
