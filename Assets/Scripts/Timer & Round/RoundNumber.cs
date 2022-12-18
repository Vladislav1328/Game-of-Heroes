using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundNumber : MonoBehaviour
{
    //����� ������ ���������� � ������� TimerController (����� TimersCheck)
  
    public int roundNumber { get; set; } = 1;
    public bool condition { get; set; } = false;
    public TimerController timerController;
    private Text roundNumTXT;

    private void Start()
    {
        roundNumTXT = this.GetComponent<Text>();
    }

    private void Update()
    {
        RoundNumberPrint();
    }
    
    //������� �������� ������ � ���
    private void RoundNumberPrint()
    {
        roundNumTXT.text = "Round "+Mathf.Round(roundNumber).ToString();
    }

    //������ ��� ��������� �� ������� TimerController: 
    //��������� ������ ���������� ����������� �������� �������� ���������� ������ ������
    public void RoundConditionSet()
    {
        condition = true;
    }

    //������ �������� ������ ������ 
    public void RoundPlus()
    {
        if (condition)
            roundNumber++;
            condition = false;
    }
}
