namespace ProjectRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PC pc = new PC(new Class_Figther());
            Console.WriteLine(pc.NAME);
            Console.WriteLine(pc.HP);
            Console.WriteLine(pc.SP);
            for(int i = 0; i < pc.SKILLSLOT.SIZE; i++)
            {
                if (pc.SKILLSLOT.SKILLS[i] != null)
                    Console.Write(pc.SKILLSLOT.SKILLS[i].NAME);
                else
                    break;
                Console.Write(", ");
            }
            Console.WriteLine();
            Console.WriteLine();

            PC pc2 = new PC(new Class_Figther());
            Console.WriteLine(pc2.NAME);
            Console.WriteLine(pc2.HP);
            Console.WriteLine(pc2.SP);
            for (int i = 0; i < pc2.SKILLSLOT.SIZE; i++)
            {
                if (pc2.SKILLSLOT.SKILLS[i] != null)
                    Console.Write(pc2.SKILLSLOT.SKILLS[i].NAME);
                else
                    break;
                Console.Write(", ");
            }
            Console.WriteLine();

            pc.UseSkill(0, pc2);
            pc.UseSkill(1, pc2);
            pc2.UseSkill(0, pc);
            pc2.UseSkill(1, pc);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(pc.NAME);
            Console.WriteLine(pc.HP);
            Console.WriteLine(pc.SP);
            for (int i = 0; i < pc.SKILLSLOT.SIZE; i++)
            {
                if (pc.SKILLSLOT.SKILLS[i] != null)
                    Console.Write(pc.SKILLSLOT.SKILLS[i].NAME);
                else
                    break;
                Console.Write(", ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(pc2.NAME);
            Console.WriteLine(pc2.HP);
            Console.WriteLine(pc2.SP);
            for (int i = 0; i < pc2.SKILLSLOT.SIZE; i++)
            {
                if (pc2.SKILLSLOT.SKILLS[i] != null)
                    Console.Write(pc2.SKILLSLOT.SKILLS[i].NAME);
                else
                    break;
                Console.Write(", ");
            }
            Console.WriteLine();
        }
    }
}