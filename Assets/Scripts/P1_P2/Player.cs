using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : IHero
{
    public override string heroName { get; set; }
    public override ConsumbleTypes consumble { get; set; }
    public override int heroHP { get; set; }
    public bool heroIsChoosen { get; set; } = false; //�������� � ����, ����� ����������� ������, ����� ��� ������ �����
    public override int pAtk { get; set; }
    public override int pDef { get; set; }
    public override int mAtk { get; set; }
    public override int mDef { get; set; }

    public override int SkillCD1 { get; set; }
    public override int SkillCD2 { get; set; }
    public override int SkillCD3 { get; set; }
    public override int SkillCD4 { get; set; }

    public override int lvlupHP { get; set; }
    public override int lvlupPatk { get; set; }
    public override int lvlupPdef { get; set; }
    public override int lvlupMatk { get; set; }
    public override int lvlupMdef { get; set; }
    //
    public Paladin paladin;
    public Warrior warrior;

    [SerializeField] public IHero choosenHero;
    public TimerController timerController;
    public RoundNumber roundNumber;
    //
    public Image autoattackBut;
    public Image Skill1kBut;
    public Image Skill2kBut;
    public Image Skill3kBut;
    public Image Skill4kBut;

    //
    public bool autoattackIsActive;
    public bool skill_1IsActive;
    public bool skill_2IsActive;
    public bool skill_3IsActive;
    public bool skill_4IsActive;
    //
    public bool autoattacCast = false;
    public bool skill1Cast = false;
    public bool skill2Cast = false;
    public bool skill3Cast = false;
    public bool skill4Cast = false;
    //
    public ActionSlotsController actionSlots;
    private float _endTimer;
    private float _startTimer;
    private int _rNum;
    public bool mayResetSkills;
    public bool mayCheckSkills = false;
    public bool skillsBlock = false;
    //
    public GameObject buffSlot1;
    public GameObject buffSlot2;
    public GameObject buffSlot3;
    public GameObject buffSlot4;
    public GameObject buffSlot5;

    //------------------------------------------------
    //����, ����������� ��� ���������� ������ 
    //���� �����, ����������� ��������� (����� ������������ ��� ������������ ������)
    //�������� ��������������� � ������� ��������� ������ ���������� ������ � ��� 
    //��������������� ������ � �� ���������� �������, ������� �������� ������ �����
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
    //���� �����, ���������� �� ��, ������� ����� ����� ������� �� ��� ���� ������ �����
    private int _buffS1Dur = 0; 
    private int _buffS2Dur = 0;
    private int _buffS3Dur = 0;
    private int _buffS4Dur = 0;
    private int _buffS5Dur = 0;
    //���� �����, ������ ��� �������� ������ � �������� ���� ��� ����� ����� � �����-���� ����� ������(������������)
    private int buffS1CD = 0; 
    private int buffS2CD = 0;
    private int buffS3CD = 0;
    private int buffS4CD = 0;
    private int buffS5CD = 0;
    private int buffS6CD = 0;
    private int buffS7CD = 0;
    private int buffS8CD = 0;
    private int buffS9CD = 0;
    private int buffS10CD = 0;

    void Start()
    {
        _rNum = roundNumber.roundNumber;
        mayResetSkills = true;
    }
    void Update()
    {
        SkillsCast();
        SkillsCheck();
        TimersCheck();
        AutoattackSet();
        RoundNumberCheck();
        BuffsIconsConceal();
        BuffsConceal();
    }

    //���������� ���. ����������, ����������� ��� ������������ ��������
    private void TimersCheck()
    {
        _endTimer = timerController.endTimer.time;
        _startTimer = timerController.startTimer.time;
    }

    //��������� ���� ������������� ������ �������, ��� ������ ��������
    public void SetPaladin()
    {
        //��������� �������� ������������ ����� �� ������� ������ ��������
        //***********************************************************************************(�� ��������)
        //***********************************************************************************���� ���� ������� �� ��������� � ������ ����� ��� ������ ���� ������� ������, ��� ������ ����
        BuffS1Duration = paladin.BuffS1Duration;

        //��������� ��������, �� ������� ����� ������������ ����� ��� ����� ���
        lvlupHP = paladin.lvlupHP;
        lvlupPatk = paladin.lvlupPatk;
        lvlupPdef = paladin.lvlupPdef;
        lvlupMatk = paladin.lvlupMatk;
        lvlupMdef = paladin.lvlupMdef;
        //����� ����
        mayCheckSkills = true;
        heroIsChoosen = true;// ���� ����� ��� ������������ �������, ����� ����� ��� ������

        //��������� ���������� ������ � �����������
        //�� ������������ choosenHero ����� ������� ������ ���������� ������
        choosenHero = paladin;

        //��������� ������ ���������� ������ � ����� ������ 
        heroName = paladin.heroName;
        heroHP = paladin.heroHP;
        consumble = paladin.consumble;
        pAtk = paladin.pAtk;
        pDef = paladin.pDef;
        mAtk = paladin.mAtk;
        mDef = paladin.mDef;
        //��������� ������ ������� ��������� � ������ �� �������� � �������� �����, ���������� �������
        autoattackBut.sprite = paladin.autoattackIMG.sprite;
        Skill1kBut.sprite = paladin.Skill1IMG.sprite;
        Skill2kBut.sprite = paladin.Skill2IMG.sprite;
        Skill3kBut.sprite = paladin.Skill3IMG.sprite;
        Skill4kBut.sprite = paladin.Skill4IMG.sprite;
        //��������� �������� ��������� �������
        SkillCD1 = paladin.SkillCD1;
        SkillCD2 = paladin.SkillCD2;
        SkillCD3 = paladin.SkillCD3;
        SkillCD4 = paladin.SkillCD4;
    }
    public void SetWarrior()
    {
        //��������� ��������, �� ������� ����� ������������ ����� ��� ����� ���
        lvlupHP = warrior.lvlupHP;
        lvlupPatk = warrior.lvlupPatk;
        lvlupPdef = warrior.lvlupPdef;
        lvlupMatk = warrior.lvlupMatk;
        lvlupMdef = warrior.lvlupMdef;

        //����� ����
        mayCheckSkills = true;
        heroIsChoosen = true;// ���� ����� ��� ������������ �������, ����� ����� ��� ������

        //��������� ���������� ������ � �����������
        //�� ������������ choosenHero ����� ������� ������ ���������� ������
        choosenHero = warrior;

        //��������� ������ ���������� ������ � ����� ������ 
        heroName = warrior.heroName;
        heroHP = warrior.heroHP;
        consumble = warrior.consumble;
        pAtk = warrior.pAtk;
        pDef = warrior.pDef;
        mAtk = warrior.mAtk;
        mDef = warrior.mDef;
        //��������� ������ ������� ��������� � ������ �� �������� � �������� �����, ���������� �������
        autoattackBut.sprite = warrior.autoattackIMG.sprite;
        Skill1kBut.sprite = warrior.Skill1IMG.sprite;
        Skill2kBut.sprite = warrior.Skill2IMG.sprite;
        Skill3kBut.sprite = warrior.Skill3IMG.sprite;
        Skill4kBut.sprite = warrior.Skill4IMG.sprite;
        //��������� �������� ��������� �������
        SkillCD1 = warrior.SkillCD1;
        SkillCD2 = warrior.SkillCD2;
        SkillCD3 = warrior.SkillCD3;
        SkillCD4 = warrior.SkillCD4;
    }

    //����� ������ ��� ��������� ����������� ��������� ���������
    //���� ��������� - ���������� �������������
    private void AutoattackSet()
    {
        if (_startTimer >= 59)
        {
            Autoattack();
        }
    }

    //Autoattack (���������� ����������)
    public override void Autoattack()
    {
        autoattackIsActive = true;
    }
    //SKill 1 (���������� ����������)
    public override void Skill1()
    {

        if (skillsBlock == false)  //�������� �� ��, ����� �� ����� �����. 
        {                          //���� ����� ��� ������ �����, �� ���������� �� ������
            skill_1IsActive = true;
            skill_2IsActive = false;
            skill_3IsActive = false;
            skill_4IsActive = false;
            skillsBlock = true;
        }
        //���������� �������
        //�������� �� ��, ���� �� � ������������ ������ ��� ���������� ������ (��� ������� ����� � ����)
        //����� �������� �� ��, �� ����������� �� �� �������� � �������������� ����, ���������� �� �� ������
        //���� 0 - �� ���� ���� ����� ����� ����� - ����������� ��������� ������ ������ � ��������� � ��� ������� �������
        //���������� ������� ������� � ���������� ������ ��������� � ��������� ������� BuffsIconsConceal() � BuffsConceal()
        //������ ����� ������������� � ������������ � ����� ������� ������, ���� � ������ �� ��� ��� ���� ������ ������ ���� ����
        if (heroName == "Paladin") 
        {
            if (buffS1CD == 0)
            {
                GetFreeBuffSlot(Skill1kBut.sprite, BuffS1Duration);
                buffS1CD = _rNum + BuffS1Duration;
            }
        }
    }
    public override void Skill2()
    {
        if (skillsBlock == false)
        {
            skill_2IsActive = true;
            skill_1IsActive = false;
            skill_3IsActive = false;
            skill_4IsActive = false;

            skillsBlock = true;
        }
    }
    public override void Skill3()
    {
        if (skillsBlock == false)
        {
            skill_3IsActive = true;
            skill_1IsActive = false;
            skill_2IsActive = false;
            skill_4IsActive = false;

            skillsBlock = true;
        }
    }
    public override void Skill4()
    {
        if (skillsBlock == false)
        {
            skill_4IsActive = true;
            skill_1IsActive = false;
            skill_2IsActive = false;
            skill_3IsActive = false;

            skillsBlock = true;
        }
    }

    //� ������ ������ ���������� ���, ��� �������������� ��� ���������� ������
    //� ������ ������ - ������������ �������� ���������� �������
    private void RoundNumberCheck()
    {
        if (_rNum != roundNumber.roundNumber)
        {
            if (skill_1IsActive == true)
            {
                skill_1IsActive = false;
            }
            if (skill_2IsActive == true)
            {
                skill_2IsActive = false;
            }
            if (skill_3IsActive == true)
            {
                skill_3IsActive = false;
            }
            if (skill_4IsActive == true)
            {
                skill_4IsActive = false;
            }
            _rNum = roundNumber.roundNumber;
            skillsBlock = false; // ����� ������� �� ����� ������
        }
    }

    //________���� �������________
    //����� ������� ��������� + ��������� ������, ����� ���������� ������ ����
    private void SkillsCast()
    {
        //�������� �� ������� ���� (��������� ���� 2)
        if (timerController.PhaseII_isActive)
        {
            //�������� �� ����������� ������������ ������
            if (mayCheckSkills)
            {
                //���� ���������
                if (autoattackIsActive)
                {
                    choosenHero.Autoattack();
                }
                //���� ������ 1
                if (skill_1IsActive)
                {
                    choosenHero.Skill1();  
                }
                //���� ������ 2
                if (skill_2IsActive)
                {
                    choosenHero.Skill2();  
                }
                //���� ������ 3
                if (skill_3IsActive)
                {
                    choosenHero.Skill3();
                }
                //���� ������ 4
                if (skill_4IsActive)
                {
                    choosenHero.Skill4();
                }
            }
        }
        // ������ �� ����������� ������������ ������ (��������� ��� ������ ���� 1 � ������ SkillsCheck).
        mayCheckSkills = false;
    }

    //����� ��������� ����������� ����� ��������� ������� (� ������ ������ ����)
    //�� ��� ���, ���� �� ���������� ������ ����
    private void SkillsCheck()
    {
        //����� ������� �� ����������� ����� ������� (��� ������ ���� 1)
        if (timerController.PhaseI_isActive == true)
        {
            if (mayCheckSkills == false)
            {
                mayCheckSkills = true;
            }
        }
    }

    //����� ����� ��� ��������� ������ ������ ��� ��������� ������
    //���������� �� LevelController � ������ LevelUP
    public void LevelUP()
    {
        heroHP += lvlupHP;
        pAtk += lvlupPatk;
        pDef += lvlupPdef;
        mAtk += lvlupMatk;
        mDef += lvlupMdef;
    }

    //_______�����________

    //�����, ��������������� �������� ����� � ��������� ����
    //��������� 2 ���������: ������ ������ � �������� ������������ ����, ������� ���� ����� �������
    //������ ������, � ���������� ���������� �� ������������ ����� ������ - ��������������� ��������
    // (������� ����� + durValue �� ���� ������������)
    //� ���� ��������, ��������� ���������� � ��� �����, ������� �������� 
    //4 ������� � if � ���������� ����� ��������������� ������������ ������� ��� ����������� ������������ �� �����
    private void GetFreeBuffSlot(Sprite skillImg, int durValue)
    {
        if (buffSlot1.active == false)
        {
            buffSlot1.SetActive(true);
            buffSlot1.GetComponent<Image>().sprite = skillImg;
            _buffS1Dur = _rNum + durValue;
            buffSlot1.GetComponent<BDBSlot>().duration = durValue;

        }
        else if (buffSlot2.active == false)
        {
            buffSlot2.SetActive(true);
            buffSlot2.GetComponent<Image>().sprite = skillImg;
            _buffS2Dur = _rNum + durValue;
            buffSlot2.GetComponent<BDBSlot>().duration = durValue;
        }
        else if (buffSlot3.active == false)
        {
            buffSlot3.SetActive(true);
            buffSlot3.GetComponent<Image>().sprite = skillImg;
            _buffS3Dur = _rNum + durValue;
            buffSlot3.GetComponent<BDBSlot>().duration = durValue;
        }
        else if (buffSlot4.active == false)
        {
            buffSlot4.SetActive(true);
            buffSlot4.GetComponent<Image>().sprite = skillImg;
            _buffS4Dur = _rNum + durValue;
            buffSlot4.GetComponent<BDBSlot>().duration = durValue;
        }
        else if (buffSlot5.active == false)
        {
            buffSlot5.SetActive(true);
            buffSlot5.GetComponent<Image>().sprite = skillImg;
            _buffS5Dur = _rNum + durValue;
            buffSlot5.GetComponent<BDBSlot>().duration = durValue;
        }
    }
    //����� �������� �� ���� ����� ������ �����. ���� �� ���� ��������� - ���������� ���������� ������ 
    //�� ������� ���������� �� �����������, ������ ���������� ������
    private void BuffsIconsConceal()
    {
        if (_buffS1Dur !=0)
        {
            if (_buffS1Dur == _rNum)
            {
                buffSlot1.SetActive(false);
            }
        }
        if (_buffS2Dur != 0)
        {
            if (_buffS1Dur == _rNum)
            {
                buffSlot2.SetActive(false);
            }
        }
    }
    //����� �������� �� ��, �� ���� �� ��������� ������ ��� ������������� ���� ��� ����� ������� ����� �� ������
    //�� ������� ����� �� �������� � �� ������ ������ ������ ��� �� �������� �� �������� ���� �� �����.
    //���� ���������� ����� � �������� ���� ������ �����, �� � ������ ����� ��� �� (�� ���� �� ��� �������� ���� �� ���
    //�������� �� ������ � ���� ��� �� ������ � ���� ��� ��) �� ���� ���� ������ �� ���������� � �� ���������, �� ��� ����� ���������
    private void BuffsConceal()
    {
        if (buffS1CD != 0)
        {
            if (buffS1CD == _rNum)
            {
                buffS1CD = 0;
            }
        }
    }
}
