using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public bool PhaseI_isActive { get; set; } = true;
    public bool PhaseII_isActive { get; set; } = false;

    public Timer startTimer;
    public Timer endTimer;
    public GameObject startT;
    public GameObject endT;
    public RoundNumber roundNumber;

    private void Update()
    {
        TimersCheck();
    }

    //�����, ������� ��������� ������������� �������� � ����������� �� �� �������� time
    public void TimersCheck()
    {
        if (startTimer.time <= 0) //��������: ������ �� ������ ����
        {
            if (startTimer.condition == true) //��������: ������� �� � ������� ��������� condition
            {
                startTimer.TimeStop();  //��������� ������� ������
                startT.SetActive(false); //�������� ������� ������ �� �����
                endTimer.TimeStart(); //��������� ��� ������
                SetEndTime(); //������������� �������� � ��� ������ �� ���������� ������

                //��� ����������� ������ �������
                //��� RoundNumber
                roundNumber.RoundConditionSet(); //���������� ����������� �������� �������� ���������� ������
                PhaseIReset();
            }
        }
        if (endTimer.time <= 0)
        {
            if (endTimer.condition == true)
            {   //����������� �������� �� �������� � �����������
                endTimer.TimeStop();
                endT.SetActive(false);
                startTimer.TimeStart();
                SetStartTime();

                //��� ����������� ������ �������
                //��� RoundNumber
                roundNumber.RoundPlus(); //������ �������� ������ ������ (� ����� �����, ����� ������ ��� �����������)
                PhaseIIReset();
            }
        }
    }

    //��������� ������ ��� ��������� � ������� �� ��������� �������� 
    //��������������� �����, � �����������, � �� � ������� �������� ������ ��� � ��� 1 ����� ������
    private void SetStartTime()
    {
        startTimer.time = 60;
        startT.SetActive(true);
    }
    private void SetEndTime()
    {
        endTimer.time = 6;
        endT.SetActive(true);
    }

    //��������� ������ ��� ����� ��������� ����������, ���������� �� ���� 1 � 2
    //���������� ����� ��� ����������� ��������� � ��� � ����� ������ ������� ���� ������
    private void PhaseIReset()
    {
        if (PhaseI_isActive == true)
        {
            PhaseI_isActive = false;
            PhaseII_isActive = true;
        }

    }
    private void PhaseIIReset()
    {
        if (PhaseII_isActive == true)
        {
            PhaseII_isActive = false;
            PhaseI_isActive = true;
        }
    }

    //����� ��� ������ �� ������ ��� ������, ������������� ������� �� 0, ��� ����� ������� ������ ���� ������
    public void EndRoundButtonClick()
    {
        startTimer.time = 0;
    }

    //����� ��� ������ �� ������ ���������� ���������, ��������� ������ �
    //������������� �������� �������� (����� ����� �������� ���������)
    public void ForChooseButton()
    {
        startTimer.TimeStart();
        SetStartTime();
    }
}
