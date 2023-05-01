using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjectRPG
{
    internal static class DataManager
    {
        // 저장 경로
        static string path = "save.dat";

        /// <summary>
        /// 데이터를 저장하는 메소드
        /// </summary>
        /// <param name="_player">플레이어</param>
        public static void SaveFile(Player _player)
        {
            SerializedPlayer player = _player.GetSerialized();  // 직렬화 플레이어 클래스로 데이터를 저장

            BinaryFormatter formatter = new BinaryFormatter();                  // BinaryFormatter,
            using (FileStream stream = new FileStream(path, FileMode.Create))   // FileStream 을 이용하여 저장
            {
                formatter.Serialize(stream, player);    // 직렬화한 데이터를 저장
            }
        }

        /// <summary>
        /// 데이터를 불러오는 메소드
        /// </summary>
        /// <returns>직렬화 플레이어 데이터 클래스</returns>
        public static SerializedPlayer LoadFile()
        {
            SerializedPlayer player;    // 직렬화한 플레이어 데이터
            BinaryFormatter formatter = new BinaryFormatter();                  // BinaryFormatter,
            using (FileStream stream = new FileStream(path, FileMode.Open))     // FileStream 을 이용하여 불러오기
            {
                player = (SerializedPlayer)formatter.Deserialize(stream);   // 직렬화한 데이터에 저장
            }

            return player;  // 직렬화된 플레이어 데이터 클래스를 반환
        }
    }
}
