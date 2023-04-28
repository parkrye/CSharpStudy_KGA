using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjectRPG
{
    internal static class DataManager
    {
        static string path = "save.dat";

        public static void SaveFile(Player _player)
        {
            SerializedPlayer player = _player.GetSerialized();

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(stream, player);
            }
        }

        public static SerializedPlayer LoadFile()
        {
            SerializedPlayer player;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                player = (SerializedPlayer)formatter.Deserialize(stream);
            }

            return player;
        }
    }

    [Serializable]
    internal class Memento
    {
        public Player player;

        public Memento(Player _player)
        {
            player = _player;
        }
    }
}
