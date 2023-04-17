using Personal_ProjectD.Characters;
using Personal_ProjectD.Classes;
using Personal_ProjectD.Races;

namespace Personal_ProjectD
{
    internal class Program
    {
        static void PPDMain(string[] args)
        {
            Character npc = new Character();
            CharacterMaking maker = new CharacterMaking();
            maker.NPCMaking(npc, "npc", 1, new int[6] { 12, 12, 12, 12, 12, 12 }, new Class_Figther(), new Race_Elf_Wood());
            npc.PrintCharacter();
        }
    }
}