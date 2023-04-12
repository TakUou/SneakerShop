using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerShop
{
    internal class MySerializator
    {
        public static T MyDeserializer<T>(string name)
        {
            string json = File.ReadAllText(name);
            T globalNotes = JsonConvert.DeserializeObject<T>(json);
            return globalNotes;
        }
        public static void MySerializer<T>(T Notes, string name)
        {
            string json = JsonConvert.SerializeObject(Notes);
            File.WriteAllText(name, json);
        }
    }
}
