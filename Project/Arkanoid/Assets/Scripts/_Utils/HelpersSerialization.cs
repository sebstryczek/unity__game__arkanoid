using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Utils
{
    static class HelpersSerialization
    {
        public static void Serialize<T>(T obj, string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            bf.Serialize(stream, obj);
            stream.Close();
        }

        public static T Deserialize<T>(string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            T obj = (T)bf.Deserialize(stream);
            stream.Close();
            return obj;
        }
    }
}
