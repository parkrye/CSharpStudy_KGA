using Personal_ProjectD.Classes;
using Personal_ProjectD.Interfaces;
using Personal_ProjectD.Items;
using Personal_ProjectD.Races;
using Personal_ProjectD.Skills;

namespace Personal_ProjectD.Characters
{
    public class Character : IDamageGetable
    {
        string characterName;
        int[] characterStatus;

        Race characterRace;
        Class characterClass;
        Skill[] characterSkills;
        Item[] characterItems;

        int characterHitDice;
        int characterHp;
        int characterLevel;
        int characterExp;

        bool[] characterArmorProficiencies;
        bool[] characterWeaponProficiencies;

        int[] characterPosition;

        public void GetDamage(int damage)
        {
            characterHp -= damage;
        }


        public Character()
        {
            characterName = "";
            characterStatus = new int[6];
            characterHitDice = 0;
            characterHp = 0;
            characterLevel = 1;
            characterExp = 0;
            characterSkills = new Skill[18];
            characterSkills[0] = new Skill_Acrobatics();
            characterSkills[1] = new Skill_AnimalHandling();
            characterSkills[2] = new Skill_Arcana();
            characterSkills[3] = new Skill_Athletics();
            characterSkills[4] = new Skill_Deception();
            characterSkills[5] = new Skill_History();
            characterSkills[6] = new Skill_Insight();
            characterSkills[7] = new Skill_Intimitation();
            characterSkills[8] = new Skill_Investigation();
            characterSkills[9] = new Skill_Medicine();
            characterSkills[10] = new Skill_Nature();
            characterSkills[11] = new Skill_Perception();
            characterSkills[12] = new Skill_Performance();
            characterSkills[13] = new Skill_Persuasion();
            characterSkills[14] = new Skill_Religion();
            characterSkills[15] = new Skill_SleightOfHand();
            characterSkills[16] = new Skill_Stealth();
            characterSkills[17] = new Skill_Survival();
            characterItems = new Item[100];
            characterArmorProficiencies = new bool[4];
            characterWeaponProficiencies = new bool[2];
            characterPosition = new int[2];
        }

        public void NPCSetting(string _characterName, int _characterLevel, Class _characterClass, Race _characterRace)
        {
            characterName = _characterName;
            characterLevel = _characterLevel;
            characterClass = _characterClass;
            characterRace = _characterRace;
        }

        public void PrintCharacter()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine("이름 : {0}", characterName);
            Console.WriteLine("레벨 : {0} / 경험치 : {1}", characterLevel, characterExp);
            Console.WriteLine("종족 : {0} / 클래스 : {1}", characterRace.GetRaceName(), characterClass.GetClassName());
            Console.WriteLine("=====================================================");
            Console.WriteLine("근력 : {0} ({1}) | 민첩 : {2} ({3}) | 건강 : {4} ({5})", characterStatus[0], GetCharacterStatusModifier(0), characterStatus[1], GetCharacterStatusModifier(1), characterStatus[2], GetCharacterStatusModifier(2));
            Console.WriteLine("지능 : {0} ({1}) | 지혜 : {2} ({3}) | 매력 : {4} ({5})", characterStatus[3], GetCharacterStatusModifier(3), characterStatus[4], GetCharacterStatusModifier(4), characterStatus[5], GetCharacterStatusModifier(5));
            Console.WriteLine("=====================================================");
            Console.Write("보유 장비 : ");
            for (int i = 0; i < characterItems.GetLength(0); i++)
            {
                if (characterItems[i] == null)
                    break;
                Console.Write(characterItems[i].GetItemName() + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("=====================================================");
            Console.Write("기술 숙련 : ");
            for (int i = 0; i < characterSkills.GetLength(0); i++)
            {
                if (characterSkills[i].GetSkilled())
                {
                    Console.Write(characterSkills[i].GetSkillName() + ", ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("=====================================================");
            Console.Write("장비 숙련 : ");
            for (int i = 0; i < characterArmorProficiencies.GetLength(0); i++)
            {
                if (characterArmorProficiencies[i])
                {
                    Console.Write((ArmorType)i + ", ");
                }
            }
            for (int i = 0; i < characterWeaponProficiencies.Length; i++)
            {
                if (characterWeaponProficiencies[i])
                {
                    Console.Write((WeaponType)i + ", ");
                }
            }
            Console.WriteLine();
        }

        public bool[] GetCharacterArmorProficiencies()
        {
            return characterArmorProficiencies;
        }

        public void SetCharacterArmorProficiencies(int index, bool value)
        {
            characterArmorProficiencies[index] = value;
        }

        public bool[] GetCharacterWeaponProficiencies()
        {
            return characterWeaponProficiencies;
        }

        public void SetCharacterWeaponProficiencies(int index, bool value)
        {
            characterWeaponProficiencies[index] = value;
        }

        public int GetCharacterHitDice()
        {
            return characterHitDice;
        }

        public void SetCharacterHitDice(int value)
        {
            characterHitDice = value;
        }

        public int GetCharacterLevel()
        {
            return characterLevel;
        }

        public void SetCharacterLevel(int value)
        {
            characterLevel = value;
        }

        public int GetCharacterExp()
        {
            return characterExp;
        }

        public void AddCharacterExp(int value)
        {
            characterExp += value;
            while(characterExp >= (characterLevel * characterLevel) * 100)
            {
                characterLevel++;
            }
        }

        public int GetCharacterHP()
        {
            return characterHp;
        }

        public void SetCharacterHP(int value)
        {
            characterHp = value;
        }

        public void SetCharacterSkill(Skill skill)
        {
            for(int i = 0; i < characterSkills.Length; i++)
            {
                if (characterSkills[i].GetSkillName() == skill.GetSkillName())
                    characterSkills[i].Skilled();
            }
        }

        public void SetCharacterName(string _characterName)
        {
            characterName = _characterName;
        }

        public string GetCharacterName()
        {
            return characterName;
        }

        public void SetCharacterRace(Race _characterRace)
        {
            characterRace = _characterRace;
        }

        public Race GetCharacterRace()
        {
            return characterRace;
        }

        public void SetCharacterClass(Class _characterClasse)
        {
            characterClass = _characterClasse;
        }

        public Class GetCharacterClass()
        {
            return characterClass;
        }

        public int[] GetCharacterStatus()
        {
            return characterStatus;
        }

        public void SetCharacterStatus(int index, int value)
        {
            characterStatus[index] = value;
        }

        public int GetCharacterStatusModifier(int index)
        {
            return characterStatus[index] / 2 - 5;
        }

        public Item GetCharacterItems(int index)
        {
            return characterItems[index];
        }

        public void AddItemToCharacter(Item item)
        {
            for(int i = 0; i < characterItems.GetLength(0); i++)
            {
                if (characterItems[i] == null)
                {
                    characterItems[i] = item;
                    break;
                }
            }
        }

        public int[] GetCharacterPosition()
        {
            return characterPosition;
        }

        public void MoveCharacter(int x, int y)
        {
            characterPosition[0] = x;
            characterPosition[1] = y;
        }
    }
}
