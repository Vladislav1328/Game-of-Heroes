using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BDBSlot : MonoBehaviour
{
    //������ ���\����� �����, ��������� ����, ������ ��� ����������� ������������ ���������� �������
    //�������� ������������ ���������� � ������������� ������ ���� �������� � ��������������� ������ ����� �������

    public Text durationTXT;
    public RoundNumber rNum;
    private int _rNum;
    public int duration;

    private void Start()
    {
        _rNum = rNum.roundNumber;
    }
    private void Update()
    {
        RoundCheck();
        durationTXT.text = duration.ToString(); //���������� ����� �������� ������������ � ��� 
    }

    //���������� �������� ������� �, ���� ���� ��� ������ - ��������� ��� ������������
    private void RoundCheck()
    {
        if (_rNum != rNum.roundNumber)
        {
            _rNum = rNum.roundNumber;
            if (duration >= 0)
            {
                duration -= 1;
            }
        }
    }
}
