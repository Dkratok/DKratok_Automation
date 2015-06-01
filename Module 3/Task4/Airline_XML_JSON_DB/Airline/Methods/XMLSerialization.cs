using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Airline.Methods
{
    [Serializable]
    public class XMLSerialization
    {

        public XMLSerialization() : base() { }
        public static void XMLFileSerialization()
        {
            string filename = "../../Planes.xml";
            TextWriter writer = new StreamWriter(filename);

            XmlSerializer serializer = new XmlSerializer(typeof(List<AviaModel>), new Type[] { typeof(PassPlane), typeof(CargoAirplane), typeof(Helicopter) });
            {
                serializer.Serialize(writer, AviaModel.planes);
            }
            writer.Close();
        }
        public static List<AviaModel> DeserializeFromXML()
        {
            string XMLFileName = "../../Planes.xml";
            Stream reader = new FileStream(XMLFileName, FileMode.Open);
            XmlSerializer deserializer = new XmlSerializer(typeof(List<AviaModel>), new Type[] { typeof(PassPlane), typeof(CargoAirplane), typeof(Helicopter) });
            List<AviaModel> Deserilizeairplanes;
            Deserilizeairplanes = (List<AviaModel>)deserializer.Deserialize(reader);
            reader.Close();
            //output to the Form
            return Deserilizeairplanes;
        }
    }
}
