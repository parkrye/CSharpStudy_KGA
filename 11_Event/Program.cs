using _12.Event.Basic;

namespace _12.Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventClass.Test();

            Player player = new Player();
            UI ui = new UI();
            SFX sfx = new SFX();
            VFX vfx = new VFX();

            // 이벤트에 반응할 함수 추가
            player.OnGetCoint += ui.CoinUI;
            player.OnGetCoint += sfx.CoinSound;
            player.OnGetCoint += vfx.CoinEffect;

            // 플레이어가 코인을 얻음 => UI 갱신 => 효과음 재생 =? 이펙트 재생
            player.GetCoin();
        }
    }
}