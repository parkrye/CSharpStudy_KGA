using Personal_ProjectD.Races;
using Personal_ProjectD.Classes;
using Personal_ProjectD.Skills;

namespace Personal_ProjectD.Characters
{
    public class CharacterMaking
    {
        public Character NPCMaking(Character character, string npcName, int npcLevel, int[] status, Class npcClass, Race npcRace)
        {
            character.NPCSetting(npcName, npcLevel, npcClass, npcRace);
            CharacterDetails(character, status);
            return character;
        }

        public Character StartMaking()
        {
            Character character = new Character();
            CharacterMake(character);
            int[] status = StatusSetting(character);
            CharacterDetails(character, status);
            return character;
        }

        public void CharacterDetails(Character character, int[] status)
        {
            foreach (Skill skill in character.GetCharacterClass().GetClassSkills())
                character.SetCharacterSkill(skill);
            for (int i = 0; i < character.GetCharacterClass().GetClassArmorProficiencies().GetLength(0); i++)
                character.SetCharacterArmorProficiencies(i, character.GetCharacterClass().GetClassArmorProficiencies()[i]);
            for (int i = 0; i < character.GetCharacterClass().GetClassWeaponProficiencies().GetLength(0); i++)
                character.SetCharacterWeaponProficiencies(i, character.GetCharacterClass().GetClassWeaponProficiencies()[i]);
            for (int i = 0; i < status.Length; i++)
                character.SetCharacterStatus(i, status[i]);
            for (int i = 0; i < character.GetCharacterClass().GetClassItems().GetLength(0); i++)
                character.AddItemToCharacter(character.GetCharacterClass().GetClassItems()[i]);
            character.SetCharacterHP(character.GetCharacterClass().GetClassHitPoint() + character.GetCharacterStatusModifier(2));
        }

        public int[] StatusSetting(Character character)
        {
            int[] bonusStatus = new int[6];
            int[] nowStatus = new int[6];
            for (int i = 0; i < 6; i++)
            {
                nowStatus[i] = 8;
                bonusStatus[i] += character.GetCharacterRace().GetRaceStatus()[i];
            }
            bool done = false;
            int cost = 27;
            while (!done)
            {
                Console.Clear();
                if(cost == 0)
                {
                    Console.WriteLine("[코스트를 모두 지불하였습니다]");
                    Console.WriteLine("[능력치 입력을 종료하시겠습니까? (Yes : 1 | No : 2)]");
                    if(Input() == 1)
                    {
                        done = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }

                Console.WriteLine("[코스트를 지불하여 능력치를 수정할 수 있습니다]");
                Console.WriteLine("[최소값 : 8, 최대값 : 15]");
                Console.WriteLine("[잔여 코스트 : {0}]", cost);
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine("[{0}. {1} : {2} + {3}]", (i + 1), (StatusType)i, nowStatus[i], bonusStatus[i]);
                }
                int editStatusIndex = Input() - 1;
                if(editStatusIndex >= 0 && editStatusIndex < 6)
                {
                    Console.WriteLine("");
                    Console.WriteLine("[수정하려는 능력치 : {0}]", (StatusType)editStatusIndex);
                    int editStatusPoint = Input();
                    if(editStatusPoint >= 8 && editStatusPoint <= 15)
                    {
                        int editStatusPrevCost;
                        if (nowStatus[editStatusIndex] >= 8 && nowStatus[editStatusIndex] <= 13)
                        {
                            editStatusPrevCost = (nowStatus[editStatusIndex] - 8);
                        }
                        else
                        {
                            editStatusPrevCost = (5 + (nowStatus[editStatusIndex] - 13) * 2);
                        }

                        cost += editStatusPrevCost;
                        if (editStatusPoint <= 13)
                        {
                            if (cost >= (editStatusPoint - 8))
                            {
                                cost -= (editStatusPoint - 8);
                                nowStatus[editStatusIndex] = editStatusPoint;
                            }
                            else
                            {
                                cost -= editStatusPrevCost;
                                Console.WriteLine("[잔여 코스트를 초과한 값입니다. 다시 입력해주세요]");
                            }
                        }
                        else
                        {
                            if (cost >= (5 + (nowStatus[editStatusIndex] - 13) * 2))
                            {
                                cost -= (5 + (editStatusPoint - 13) * 2);
                                nowStatus[editStatusIndex] = editStatusPoint;
                            }
                            else
                            {
                                cost -= editStatusPrevCost;
                                Console.WriteLine("[잔여 코스트를 초과한 값입니다. 다시 입력해주세요]");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("[잘못된 입력입니다. 다시 입력해주세요]");
                    }
                }
                else
                {
                    Console.WriteLine("[잘못된 입력입니다. 다시 입력해주세요]");
                }
            }
            return nowStatus;
        }

        public void CharacterMake(Character character)
        {
            Console.Clear();
            Console.WriteLine("[캐릭터 메이킹을 시작합니다]");

            bool selectRace = false, selectClass = false, inputName = false;
            while (!selectRace || !selectClass || !inputName)
            {
                if (!selectRace)
                {
                    Console.WriteLine("[1.종족 선택]");
                }
                else
                {
                    Console.WriteLine("[1.종족 선택 ({0})]", character.GetCharacterRace().GetRaceName());
                }
                if (!selectClass)
                {
                    Console.WriteLine("[2.직업 선택]");
                }
                else
                {
                    Console.WriteLine("[2.직업 선택 ({0})]", character.GetCharacterClass().GetClassName());
                }
                if (selectRace && selectClass)
                {
                    Console.WriteLine("[3.선택 완료]");
                }
                Console.WriteLine();
                switch (Input())
                {
                    case 1:
                        selectRace = true;
                        SelectRace(character);
                        break;
                    case 2:
                        selectClass = true;
                        SelectClass(character);
                        break;
                    case 3:
                        inputName = true;
                        InputPersonal(character);
                        break;
                    default:
                        Console.WriteLine("[잘못된 입력입니다. 다시 입력해주세요]");
                        break;
                }
                Console.Clear();
            }
        }

        public void SelectRace(Character character)
        {
            bool select = false;
            while (!select)
            {
                Console.Clear();
                Console.WriteLine("[선택할 수 있는 종족]");
                Console.WriteLine("[1.언덕 드워프]");
                Console.WriteLine("[2.산 드워프]");
                Console.WriteLine("[3.하이 엘프]");
                Console.WriteLine("[4.우드 엘프]");
                Console.WriteLine("[5.라이트풋 하플링]");
                Console.WriteLine("[6.스타우트 하플링]");
                Console.WriteLine("[7.인간]");

                Console.WriteLine("");
                switch (Input())
                {
                    case 1:
                        Console.WriteLine("[언덕 드워프는 날카로운 감각과 깊은 직관, 그리고 놀라운 회복력을 가지고 있습니다]");
                        character.SetCharacterRace(new Race_Dwarf_Hill());
                        break;
                    case 2:
                        Console.WriteLine("[산 드워프는 강력한 힘과 강인한 체력을 가지고 험준한 지형에서도 능숙하게 살아갑니다]");
                        character.SetCharacterRace(new Race_Dwarf_Mountain());
                        break;
                    case 3:
                        Console.WriteLine("[하이 엘프는 날카로운 정신과 기초적인 마법에 대한 최소한의 숙련을 가지고 있습니다]");
                        character.SetCharacterRace(new Race_Elf_High());
                        break;
                    case 4:
                        Console.WriteLine("[우드 엘프는 날카로운 감각과 직관, 그리고 숲을 재빠르게 오갈 수 있는 민첩함을 가지고 있습니다]");
                        character.SetCharacterRace(new Race_Elf_Wood());
                        break;
                    case 5:
                        Console.WriteLine("[라이트풋 하플링은 작은 체구로 다른 사람을 엄폐물로 사용해 시야에서 손쉽게 숨을 수 있습니다]");
                        character.SetCharacterRace(new Race_Halfling_LightFoot());
                        break;
                    case 6:
                        Console.WriteLine("[스타우트 하플링은 강인한 체력과 독에 대한 저항을 가지고 있습니다]");
                        character.SetCharacterRace(new Race_Halfling_Stout());
                        break;
                    case 7:
                        Console.WriteLine("[인간은 다른 종족들과 달리 특화된 능력을 갖지 않은 대신 다양한 능력을 조금씩 가지고 있습니다]");
                        character.SetCharacterRace(new Race_Human());
                        break;
                    default:
                        Console.WriteLine("[잘못된 입력입니다. 다시 입력해주세요]");
                        break;
                }
                Console.WriteLine("");
                Console.WriteLine("[이 종족을 선택하시겠습니까? (Yes : 1 | No : 2)]");
                if (Input() == 1)
                    select = true;
            }

        }

        public void SelectClass(Character character)
        {
            bool select = false;
            while (!select)
            {
                Console.Clear();
                Console.WriteLine("[선택할 수 있는 직업]");
                Console.WriteLine("[1.성직자]");
                Console.WriteLine("[2.전사]");
                Console.WriteLine("[3.도적]");
                Console.WriteLine("[4.마법사]");

                Console.WriteLine("");
                switch (Input())
                {
                    case 1:
                        Console.WriteLine("[성직자는 인간 세계와 신들의 세계의 중개자입니다. 신들의 종으로서 성직자들은 그들의 신의 뜻을 펼치기 위해 노력합니다]");
                        character.SetCharacterClass(new Class_Cleric());
                        break;
                    case 2:
                        Console.WriteLine("[전사는 다양한 형태로 전투에 특화된 전문가들입니다. 전사는 누구보다 죽음과 가까운 곳에서 도전하는 이들이기도 합니다]");
                        character.SetCharacterClass(new Class_Figther());
                        break;
                    case 3:
                        Console.WriteLine("[도적은 다재다능한 솜씨를 지녔습니다. 도적은 어떤 상황에서도 유연하게 대처할 수 있기에, 파티에서 그들의 존재는 필수입니다]");
                        character.SetCharacterClass(new Class_Rogue());
                        break;
                    case 4:
                        Console.WriteLine("[마법사는 최고의 주문사용자입니다. 마법사는 우주에 스며드는 미묘한 마력의 짜임새를 이용해 다양한 강력하고 다양한 마법을 사용할 수 있습니다]");
                        character.SetCharacterClass(new Class_Wizard());
                        break;
                    default:
                        Console.WriteLine("[잘못된 입력입니다. 다시 입력해주세요]");
                        break;
                }
                Console.WriteLine("");
                Console.WriteLine("[이 직업을 선택하시겠습니까? (Yes : 1 | No : 2)]");
                if (Input() == 1)
                    select = true;
            }
        }

        public void InputPersonal(Character character)
        {
            bool select = false;
            string name = "";
            while (!select)
            {
                Console.Clear();
                Console.WriteLine("[캐릭터 이름을 입력해주세요]");
                name = Console.ReadLine();
                if(name.Length > 0)
                {
                    Console.WriteLine("[이 이름 으로 하시겠습니까? (Yes : 1 | No : 2)]");
                    if (Input() == 1)
                        select = true;
                }
            }
            character.SetCharacterName(name);
        }

        int Input()
        {
            Console.Write("입력 : ");
            int result = -1;
            int.TryParse(Console.ReadLine(), out result);
            return result;
        }
    }
}
