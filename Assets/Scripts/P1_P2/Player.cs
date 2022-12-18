using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : IHero
{
    public override string heroName { get; set; }
    public override ConsumbleTypes consumble { get; set; }
    public override int heroHP { get; set; }
    public bool heroIsChoosen { get; set; } = false; //обращясь к полю, можно отслеживать момент, когда уже выбран герой
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
    //поля, необходимые для реализации баффов 
    //блок полей, реализующих интерфейс (общие плейсхолдеры под длительность баффов)
    //значения устанавливаются в методах установки статов выбранного класса и они 
    //устанавливаются только в те переменные скиллов, которые содержат эфеект баффа
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
    //блок полей, отвечающих за то, сколько ходов будет активна та или иная иконка баффа
    private int _buffS1Dur = 0; 
    private int _buffS2Dur = 0;
    private int _buffS3Dur = 0;
    private int _buffS4Dur = 0;
    private int _buffS5Dur = 0;
    //блок полей, нужных для хранения данных о кулдауне того или иного баффа в каком-либо скиле игрока(плейсхолдеры)
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

    //Обновление лок. переменных, необходимых для отслеживания таймеров
    private void TimersCheck()
    {
        _endTimer = timerController.endTimer.time;
        _startTimer = timerController.startTimer.time;
    }

    //Установка всех комплектующих класса Паладин, при выборе паладина
    public void SetPaladin()
    {
        //установка значения длительности баффа из первого скилла паладина
        //***********************************************************************************(НЕ ДОДЕЛАНО)
        //***********************************************************************************Бафф пала зависит от автоатаки и иконка баффа нге должна быть иконкой скилла, там другой бафф
        BuffS1Duration = paladin.BuffS1Duration;

        //установка значений, на которые будут увеличиватся статы при левел апе
        lvlupHP = paladin.lvlupHP;
        lvlupPatk = paladin.lvlupPatk;
        lvlupPdef = paladin.lvlupPdef;
        lvlupMatk = paladin.lvlupMatk;
        lvlupMdef = paladin.lvlupMdef;
        //общие поля
        mayCheckSkills = true;
        heroIsChoosen = true;// поле нужно для отслеживания момента, когда класс уже выбран

        //Установка выбранного класса в плейсхолден
        //из плейсхолдера choosenHero будут браться скиллы выбранного класса
        choosenHero = paladin;

        //Установка статов выбранного класса в статы игрока 
        heroName = paladin.heroName;
        heroHP = paladin.heroHP;
        consumble = paladin.consumble;
        pAtk = paladin.pAtk;
        pDef = paladin.pDef;
        mAtk = paladin.mAtk;
        mDef = paladin.mDef;
        //Установка иконок скиллов палладина в кнопки со скиллами и остальніх полей, касающихся скиллов
        autoattackBut.sprite = paladin.autoattackIMG.sprite;
        Skill1kBut.sprite = paladin.Skill1IMG.sprite;
        Skill2kBut.sprite = paladin.Skill2IMG.sprite;
        Skill3kBut.sprite = paladin.Skill3IMG.sprite;
        Skill4kBut.sprite = paladin.Skill4IMG.sprite;
        //Установка значения кулдаунов скиллов
        SkillCD1 = paladin.SkillCD1;
        SkillCD2 = paladin.SkillCD2;
        SkillCD3 = paladin.SkillCD3;
        SkillCD4 = paladin.SkillCD4;
    }
    public void SetWarrior()
    {
        //установка значений, на которые будут увеличиватся статы при левел апе
        lvlupHP = warrior.lvlupHP;
        lvlupPatk = warrior.lvlupPatk;
        lvlupPdef = warrior.lvlupPdef;
        lvlupMatk = warrior.lvlupMatk;
        lvlupMdef = warrior.lvlupMdef;

        //общие поля
        mayCheckSkills = true;
        heroIsChoosen = true;// поле нужно для отслеживания момента, когда класс уже выбран

        //Установка выбранного класса в плейсхолден
        //из плейсхолдера choosenHero будут браться скиллы выбранного класса
        choosenHero = warrior;

        //Установка статов выбранного класса в статы игрока 
        heroName = warrior.heroName;
        heroHP = warrior.heroHP;
        consumble = warrior.consumble;
        pAtk = warrior.pAtk;
        pDef = warrior.pDef;
        mAtk = warrior.mAtk;
        mDef = warrior.mDef;
        //Установка иконок скиллов палладина в кнопки со скиллами и остальніх полей, касающихся скиллов
        autoattackBut.sprite = warrior.autoattackIMG.sprite;
        Skill1kBut.sprite = warrior.Skill1IMG.sprite;
        Skill2kBut.sprite = warrior.Skill2IMG.sprite;
        Skill3kBut.sprite = warrior.Skill3IMG.sprite;
        Skill4kBut.sprite = warrior.Skill4IMG.sprite;
        //Установка значения кулдаунов скиллов
        SkillCD1 = warrior.SkillCD1;
        SkillCD2 = warrior.SkillCD2;
        SkillCD3 = warrior.SkillCD3;
        SkillCD4 = warrior.SkillCD4;
    }

    //Метод каждый ход обновляет возможность совершить автоатаку
    //Если отключить - перестанет автоатаковать
    private void AutoattackSet()
    {
        if (_startTimer >= 59)
        {
            Autoattack();
        }
    }

    //Autoattack (Реализация интерфейса)
    public override void Autoattack()
    {
        autoattackIsActive = true;
    }
    //SKill 1 (Реализация интерфейса)
    public override void Skill1()
    {

        if (skillsBlock == false)  //проверка на то, можно ли юзать скилл. 
        {                          //если игрок уже выбрал скилл, то перепикать не сможет
            skill_1IsActive = true;
            skill_2IsActive = false;
            skill_3IsActive = false;
            skill_4IsActive = false;
            skillsBlock = true;
        }
        //РЕАЛИЗАЦИЯ ДЕБАФФА
        //проверка на то, есть ли в плейсхолдере скилла тег выбранного класса (как триггер входа в бафф)
        //далее проверка на то, не установлено ли КД значение в соответствющее поле, отвечающее за КД скилла
        //если 0 - то есть если скилл можно юзать - реализуется активация иконки скилла и установка в нее нужного спрайта
        //выключение эффекта дебаффа и активности иконки происходи в отдельных методах BuffsIconsConceal() и BuffsConceal()
        //данная хуйня прописывается в плейсхолдере с тегом нужного класса, если у класса на той или иной кнопке скилла есть бафф
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

    //В методе должно отработать все, что отрабатывается при завершении раунда
    //В данном случае - сбрасываюстя значения активности скиллов
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
            skillsBlock = false; // сброс запрета на выбор скилла
        }
    }

    //________Каст скиллов________
    //Метод кастует автоатаку + выбранные скиллы, когда начинается вторая фаза
    private void SkillsCast()
    {
        //Проверка на текущую фазу (ожидается фаза 2)
        if (timerController.PhaseII_isActive)
        {
            //проверка на возможность активировать скиллы
            if (mayCheckSkills)
            {
                //Каст автоатаки
                if (autoattackIsActive)
                {
                    choosenHero.Autoattack();
                }
                //Каст скилла 1
                if (skill_1IsActive)
                {
                    choosenHero.Skill1();  
                }
                //Каст скилла 2
                if (skill_2IsActive)
                {
                    choosenHero.Skill2();  
                }
                //Каст скилла 3
                if (skill_3IsActive)
                {
                    choosenHero.Skill3();
                }
                //Каст скилла 4
                if (skill_4IsActive)
                {
                    choosenHero.Skill4();
                }
            }
        }
        // запрет на возможность активировать скиллы (обновится при начале фазы 1 в методе SkillsCheck).
        mayCheckSkills = false;
    }

    //Метод отключает возможность каста выбранных скиллов (в начале первой фазы)
    //до тех пор, пока не начинается вторая фаза
    private void SkillsCheck()
    {
        //Сброс запрета на возможность каста скиллов (при старте фазы 1)
        if (timerController.PhaseI_isActive == true)
        {
            if (mayCheckSkills == false)
            {
                mayCheckSkills = true;
            }
        }
    }

    //Метод нужен для повышения статов плеера при повышении уровня
    //Вызывается из LevelController в методе LevelUP
    public void LevelUP()
    {
        heroHP += lvlupHP;
        pAtk += lvlupPatk;
        pDef += lvlupPdef;
        mAtk += lvlupMatk;
        mDef += lvlupMdef;
    }

    //_______Баффы________

    //Метод, устанавливающий картинку баффа в свободный слот
    //принимает 2 аргумента: нужный спрайт и значение длительности того, сколько слот будет активен
    //внутри метода, в переменную отвечающую за длительность жизни иконки - устанавливается значение
    // (текущий раунд + durValue то есть длительность)
    //в силу проверок, активация происходит в том слоте, который свободен 
    //4 строкой в if в переменную слота устанавливается длительность эффекта для отображения длительности на слоте
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
    //Метод проверки на цикл жизни иконки баффа. Если ее пора выключить - происходит выключение иконки 
    //но никакие переменные не обновляются, просто вырубается иконка
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
    //Метод проверки на то, не пора ли разрешить доступ для использования того или иного эффекта баффа из скилла
    //кд эффекта баффа не привязан к кд самого скилла потому что их кулдауны не зависимы друг от друга.
    //если кастанется скилл у которого есть эффект баффа, но у самого баффа еще кд (то есть он еще работает либо он уже
    //вырублен но доступ к нему еще не открыт в силу его кд) то этот бафф просто не кастанется и не сработает, но сам скилл сработает
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
