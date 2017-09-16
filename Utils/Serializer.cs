using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Utils
{
    public interface ISerializer
    {
        List<T> DeserializeList<T>(string path);
        void SerializeList<T>(List<T> list, string path);
    }

    public class Serializer : ISerializer
    {
        public List<T> DeserializeList<T>(string path)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(path, FileMode.Create))
            {
                if (!(formatter.Deserialize(stream) is List<T> data))
                {
                    throw new SerializationException("File couldn't be deserialized");
                }
                return data;
            }

        }

        public void SerializeList<T>(List<T> list, string path)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                formatter.Serialize(stream, list);
            }
        }
    }
}
