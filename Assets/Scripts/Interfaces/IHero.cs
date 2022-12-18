using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class IHero : MonoBehaviour
{
    public abstract string heroName { get; set; }
    public abstract int heroHP { get; set; }
    public abstract ConsumbleTypes consumble { get; set; }
    public abstract int pAtk { get; set; }
    public abstract int pDef { get; set; }
    public abstract int mAtk { get; set; }
    public abstract int mDef { get; set; }

    public abstract int lvlupHP { get; set; }
    public abstract int lvlupPatk { get; set; }
    public abstract int lvlupPdef { get; set; }
    public abstract int lvlupMatk { get; set; }
    public abstract int lvlupMdef { get; set; }

    public abstract int SkillCD1 { get; set; }
    public abstract int SkillCD2 { get; set; }
    public abstract int SkillCD3 { get; set; }
    public abstract int SkillCD4 { get; set; }


    //поля, отвечающие за длительность того или иного баффа
    public abstract int BuffS1Duration { get; set; }
    public abstract int BuffS2Duration { get; set; }
    public abstract int BuffS3Duration { get; set; }
    public abstract int BuffS4Duration { get; set; }
    public abstract int BuffS5Duration { get; set; }
    public abstract int BuffS6Duration { get; set; }
    public abstract int BuffS7Duration { get; set; }
    public abstract int BuffS8Duration { get; set; }
    public abstract int BuffS9Duration { get; set; }
    public abstract int BuffS10Duration { get; set; }

    public abstract void Autoattack();
    public abstract void Skill1();
    public abstract void Skill2();
    public abstract void Skill3();
    public abstract void Skill4();


}
