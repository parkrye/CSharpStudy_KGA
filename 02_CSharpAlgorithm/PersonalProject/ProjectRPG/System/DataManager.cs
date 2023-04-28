using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjectRPG
{
    internal static class DataManager
    {
        static string path = "save.dat";

        public static void SaveFile(Player player)
        {
            Memento memento = player.SaveState();

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, memento);
            }
        }

        public static void LoadFile(Player player)
        {
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Memento memento = (Memento)bf.Deserialize(fs);
                    player = memento.player;
                }
                Console.WriteLine("Game loaded.");
            }
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
