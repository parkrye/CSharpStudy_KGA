using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace HomeWork_8
{
    internal class Program
    {
        static void HW8Main(string[] args)
        {
            Orc orc = new("김오크", 10, 10);
            Slime slime = new("이라임", 5, 5);

            orc.TakeDamage(5);
            slime.TakeDamage(1);
            orc.UseSkill(0);
            slime.UseSkill(0);
            orc.TakeDamage(100);
            orc.UseSkill(0);
        }
    }
}