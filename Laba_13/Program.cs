using System.Security.Cryptography;
using System.Xml;
using System.Xml.Linq;
using static Laba_13.CustomSerializer;

namespace Laba_13
{
    public class Program
    {
        [Obsolete("Obsolete")]
        public static void Main()
        {
            var humanArray = new Human[2];
            humanArray[0] = new Human("Vasya", DateTime.Now, "man");
            humanArray[1] = new Human("Marta", DateTime.Now, "girl");

            Serialize("humanArray.bin", humanArray);
            Serialize("humanArray.xml", humanArray);
            Serialize("humanArray.json", humanArray);

            Deserialize("humanArray.bin");
            Deserialize("humanArray.xml");
            Deserialize("humanArray.json");

            var xDoc = new XmlDocument();
            xDoc.Load("humanArray.xml");
            var xRoot = xDoc.DocumentElement;

            Console.WriteLine("\n");
            var nodes = xRoot?.SelectNodes("Human");
            if (nodes is not null)
            {
                foreach (XmlNode node in nodes)
                    Console.WriteLine(node.OuterXml);
            }

            Console.WriteLine("\n");

            nodes = xRoot?.SelectNodes("Human/Name");
            if (nodes is not null)
            {
                foreach (XmlNode node in nodes)
                    Console.WriteLine(node.OuterXml);
            }

            var doc = XDocument.Load("humanArray.xml");
            var items = from item in doc.Element("ArrayOfHuman").Elements("Human")
                        where item.Element("Name").Value == "Marta"
                        select new Human(item.Element("Name").Value, DateTime.Now);

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}