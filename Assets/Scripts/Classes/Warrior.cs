using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warrior : IHero
{
    public override string heroName { get; set; }
    public override ConsumbleTypes consumble { get; set; }
    public override int heroHP { get; set; }
    public override int pAtk { get; set; }
    public override int pDef { get; set; }
    public override int mAtk { get; set; }
    public override int mDef { get; set; }

    public override int lvlupHP { get; set; }
    public override int lvlupPatk { get; set; }
    public override int lvlupPdef { get; set; }
    public override int lvlupMatk { get; set; }
    public override int lvlupMdef { get; set; }

    public override int SkillCD1 { get; set; }
    public override int SkillCD2 { get; set; }
    public override int SkillCD3 { get; set; }
    public override int SkillCD4 { get; set; }

    public override int BuffS1Duration { get; set; }
    public override int BuffS2Duration { get; set; }
    public override int BuffS3Duration { get; set; }
    public override int BuffS4Duration { get; set; }
    public override int BuffS5Duration { get; set; }
    public override int BuffS6Duration { get; set; }
    public override int BuffS7Duration { get; set; }
    public override int BuffS8Duration { get; set; }
    public override int BuffS9Duration { get; set; }
    public override int BuffS10Duration { get; set; }


    public Image autoattackIMG;
    public Image Skill1IMG;
    public Image Skill2IMG;
    public Image Skill3IMG;
    public Image Skill4IMG;

    public string skill1Name;
    public string skill2Name;
    public string skill3Name;
    public string skill4Name;

    public string skill1Descript;
    public string skill2Descript;
    public string skill3Descript;
    public string skill4Descript;

    private void Start()
    {
        //установка полей, отвечающих за длительность баффов в теъ или иных скиллах
        BuffS1Duration = 2;
        BuffS2Duration = 3;

        //установка значений, на которые будут увеличиватся статы при левел апе
        lvlupHP = 10;
        lvlupPatk = 2;
        lvlupPdef = 3;
        lvlupMatk = 0;
        lvlupMdef = 2;

        //Установка значений в статы класса
        heroName = "Warrior";
        heroHP = 900;
        consumble = ConsumbleTypes.None;
        pAtk = 10;
        pDef = 8;
        mAtk = 4;
        mDef = 6;

        //Установка имен и описаний скиллов
        Skill1DescriptSer();
        Skill2DescriptSer();
        Skill3DescriptSer();
        Skill4DescriptSer();

        SkillCD1 = 3;
        SkillCD2 = 3;
        SkillCD3 = 3;
        SkillCD4 = 2;
    }
    public override void Autoattack()
    {
        Debug.Log("Автоатакой наебишил Х урона");
    }

    public override void Skill1()
    {
        Debug.Log("Скилл 1 сработал");
    }

    public override void Skill2()
    {
        Debug.Log("Скилл 2 кастанулся успешно");
    }
    public override void Skill3()
    {
        Debug.Log("Скилл 3 кастанулся успешно");
    }
    public override void Skill4()
    {
        Debug.Log("Скилл 4 кастанулся успешно");
    }

    //Методы с именами и описаниями скиллов
    private void Skill1DescriptSer()
    {
        skill1Name = "Merciless Strike";
        skill1Descript = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.";
    }
    private void Skill2DescriptSer()
    {
        skill2Name = "Aggression";
        skill2Descript = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ";
    }
    private void Skill3DescriptSer()
    {
        skill3Name = "Battle Master";
        skill3Descript = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ";
    }
    private void Skill4DescriptSer()
    {
        skill4Name = "Defensive lunge";
        skill4Descript = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ";
    }
}
