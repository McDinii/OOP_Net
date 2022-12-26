using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Laba_13
{
    public static class CustomSerializer
    {
        [Obsolete("Obsolete")]
        public static void Serialize(string file, Human[] human)
        {
            var format = file.Split('.').Last();
            switch (format)
            {
                case "bin":
                    var bf = new BinaryFormatter();
                    using (var fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        bf.Serialize(fs, human);
                    }

                    break;

                /*case "soap":
                    SoapFormatter sf = new SoapFormatter();
                    using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        sf.Serialize(fs, human);
                    }
                    break;*/

                case "xml":
                    var xs = new XmlSerializer(typeof(Human[]));
                    using (var fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        xs.Serialize(fs, human);
                    }

                    break;

                case "json":
                    var js = new DataContractJsonSerializer(typeof(Human[]));
                    using (var fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        js.WriteObject(fs, human);
                    }
                    break;
            }
        }

        [Obsolete("Obsolete")]
        public static void Deserialize(string file)
        {
            var format = file.Split('.').Last();
            switch (format)
            {
                case "bin":
                    var bf = new BinaryFormatter();
                    using (var fs = new FileStream(file, FileMode.Open))
                    {
                        var human = (Human[])bf.Deserialize(fs);
                        foreach (var h in human)
                        {
                            Console.WriteLine($"Deserialized comp: {h.Name} {h.Birthday}");
                        }
                    }

                    break;

                /*case "soap":
                    SoapFormatter sf = new SoapFormatter();
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        Human human = (Human)sf.Deserialize(fs);
                    }
                    break;*/

                case "xml":
                    var xs = new XmlSerializer(typeof(Human[]));
                    using (var fs = new FileStream(file, FileMode.Open))
                    {
                        var human = (Human[])xs.Deserialize(fs)!;
                        foreach (var h in human)
                        {
                            Console.WriteLine($"Deserialized comp: {h.Name} {h.Birthday}");
                        }
                    }

                    break;

                case "json":
                    var js = new DataContractJsonSerializer(typeof(Human[]));
                    using (var fs = new FileStream(file, FileMode.Open))
                    {
                        var human = (Human[])js.ReadObject(fs)!;
                        foreach (var h in human)
                        {
                            Console.WriteLine($"Deserialized comp: {h.Name} {h.Birthday}");
                        }
                    }

                    break;
            }
        }
    }
}
