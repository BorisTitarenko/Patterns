using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Patterns
{
    class SerDes
    {
        private readonly static string filename = "E:\\NULP\\6\\Patterns\\Patterns\\Patterns\\planes.json";
        private static Object serialized;
        public static void serialize(Object o) {
            serialized = o;
            var jsonString = JsonSerializer.Serialize(o);
            //Console.WriteLine(jsonString);
            File.WriteAllText(filename, jsonString);
        }

        public static Object deserialize()
        {
            return JsonSerializer.Deserialize(File.ReadAllText(filename), serialized.GetType());
        }
    }
}
