using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSlotsController : MonoBehaviour
{
    public Image SlotMaket;
    public Image P1Slot1;
    public Image P1Slot2;
    public Image P1Slot3;
    //public ActionSlot P2Slot1;
    //public ActionSlot P2Slot2;
    //public ActionSlot P2Slot3;
    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    //public GameObject frame4;
    //public GameObject frame5;
    //public GameObject frame6;


    public TimerController timerController;
    public Player player;
    public RoundNumber roundNumber;


    private float _endTimer;
    private float _startTimer;
    private int _rNum;

    public bool autoatackUSE = false;
    public bool skill1USE = false;
    public bool skill2USE = false;

    public bool second6NOW = false;

    private void Start()
    {
        _rNum = roundNumber.roundNumber;
    }
    private void Update()
    {
        _endTimer = timerController.endTimer.time;
        _startTimer = timerController.startTimer.time;
        //FramesSet(); рамки заблочены
        ActionCheck();
        RoundNumberCheck();

       
    }

    //Если раунд изменился - слоты сбрасываются.
    private void RoundNumberCheck()
    {
        if (_rNum != roundNumber.roundNumber)
        {

            SlotsReset();
            _rNum = roundNumber.roundNumber;
        }
    }

    //6 методов для активации рамок. Методы активируют рамки согласно секундам ендгейм таймера
    //К этим же таймингам нужно будет выставить каст скиллов чтоб рамка и каст скилла работали в синхроне
    private void FramesSet()
    {
        Frame1Set();
        Frame2Set();
        Frame3Set();
    }
    private void Frame1Set()
    {
 
        if (_endTimer <= 6)
        {
            frame1.gameObject.SetActive(true); 
        }
        if (_endTimer <= 5)
        {
            frame1.gameObject.SetActive(false);
        }
    }
    private void Frame2Set()
    {
        if (_endTimer <= 5)
        {
            
            frame2.gameObject.SetActive(true);
        }
        if (_endTimer <= 4)
        {
           
            frame2.gameObject.SetActive(false);
        }
    }
    private void Frame3Set()
    {
        if (timerController.roundNumber.roundNumber >= 10)
        {
            if (_endTimer <= 4)
            {
                frame3.gameObject.SetActive(true);
            }
            if (_endTimer <= 3)
            {
                frame3.gameObject.SetActive(false);
            }
        }
    }
    
    private void ActionCheck()
    {
        if (player.autoattackIsActive == true)
        {
            P1Slot1.sprite = player.autoattackBut.sprite;
        }
        if (player.skill_1IsActive == true)
        {
            P1Slot2.sprite = player.Skill1kBut.sprite;

        }
        if (player.skill_2IsActive == true)
        {
            P1Slot2.sprite = player.Skill2kBut.sprite;

        }
        if (player.skill_3IsActive == true)
        {
            P1Slot2.sprite = player.Skill3kBut.sprite;

        }
        if (player.skill_4IsActive == true)
        {
            P1Slot2.sprite = player.Skill4kBut.sprite;

        }

        //реализовать пик второго скилла после 10 хода

    }

    private void SlotsReset()
    {
        P1Slot1.sprite = SlotMaket.sprite;
        P1Slot2.sprite = SlotMaket.sprite;
        P1Slot3.sprite = SlotMaket.sprite;
    }
}
