using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownController : MonoBehaviour
{
    public Player Player;
    public GameObject SkillButAutoattack;
    public GameObject SkillBut1;
    public GameObject SkillBut2;
    public GameObject SkillBut3;
    public GameObject SkillBut4;
    public TimerController timerController;
    [SerializeField]private RoundNumber roundNumber;
    private int _rNum;
    private int cdAutoattack;
    private int cdSkill1 = 0;
    private int cdSkill2 = 0;
    private int cdSkill3 = 0;
    private int cdSkill4 = 0;
    [SerializeField] private Text Autoattack_TxtCd;
    [SerializeField] private Text skill1_TxtCd;
    [SerializeField] private Text skill2_TxtCd;
    [SerializeField] private Text skill3_TxtCd;
    [SerializeField] private Text skill4_TxtCd;



    private void Update()
    {
        //����������� ������� �����
        _rNum = roundNumber.roundNumber;
        CoolDownTXTSet();
        CoolDownEnable();
        CoolDownDisable();
    }

    //����� ��� ��������� �������� (��������� �������� � �������� ������ ������)
    private void SetCoolDownButton(int SkillNumber)
    {
        if (SkillNumber == 0)
        {
            SkillButAutoattack.SetActive(true);
        }
        if (SkillNumber == 1)
        {
            SkillBut1.SetActive(true);
            cdSkill1 = Player.SkillCD1 + _rNum;
        }
        if (SkillNumber == 2)
        {
            SkillBut2.SetActive(true);
            cdSkill2 = Player.SkillCD2 + _rNum; ;
        }
        if (SkillNumber == 3)
        {
            SkillBut3.SetActive(true);
            cdSkill3 = Player.SkillCD3 + _rNum; ;
        }
        if (SkillNumber == 4)
        {
            SkillBut4.SetActive(true);
            cdSkill4 = Player.SkillCD4 + _rNum; ;
        }
    }
    //����� � ��������� ��������� ������ � ���������� � ���� �������� 
    private void CoolDownEnable()
    {
        if (timerController.PhaseII_isActive) //�������� �� ���� 2
        {
            //�������� �� ��������� ���� � ��������� ��� ��������
            if (Player.skill_1IsActive == true)
            {
                SetCoolDownButton(1);
            }
            if (Player.skill_2IsActive == true)
            {
                SetCoolDownButton(2);
            }
            if (Player.skill_3IsActive == true)
            {
                SetCoolDownButton(3);
            }
            if (Player.skill_4IsActive == true)
            {
                SetCoolDownButton(4);
            }
        }
    }
    //����� � ��������� ���������. �������� ������ �������, ���� ���� �� ��������
    private void CoolDownDisable()
    {
        //�������� �� ��, �� ����� �� ���������� (��� ����� ������, ���� ����� �� ���������)
        if (cdSkill1 > 0)
        {
            //�������� �� ��, ���� �� ��������� �������
            if (_rNum == (cdSkill1 + 1))
            {
                SkillBut1.SetActive(false);
                cdSkill1 = 0;
            }
        }
        if (cdSkill2 > 0)
        {
            if (_rNum == (cdSkill2 + 1))
            {
                SkillBut2.SetActive(false);
                cdSkill2 = 0;
            }
        }
        if (cdSkill3 > 0)
        {
            if (_rNum == (cdSkill3 + 1))
            {
                SkillBut3.SetActive(false);
                cdSkill3 = 0;
            }
        }
        if (cdSkill4 > 0)
        {
            if (_rNum == (cdSkill4 + 1))
            {
                SkillBut4.SetActive(false);
                cdSkill4 = 0;
            }
        }
    }
    //����� ������������� UI ����������� �������� ������ �� ����������� �� ������
    private void CoolDownTXTSet()
    {
        //�������� ��������� �� ����� �� ���������� �.�. ��������� �������������
        //��������� ������ ��� � �� ����� �������� �� �������
        if (SkillButAutoattack.active)
        {
            var cd = (cdAutoattack - _rNum) + 1;
            Autoattack_TxtCd.text = cd.ToString();
        }
        //�������� �� ��, �������� �� �� ������
        if (SkillBut1.active)
        {
            //��������� ��� ����������, ������� ���������� ������� ������
            var cd = (cdSkill1 - _rNum)+1;
            skill1_TxtCd.text = cd.ToString();
        }
        if (SkillBut2.active)
        {
            var cd = (cdSkill2 - _rNum) + 1;
            skill2_TxtCd.text = cd.ToString();
        }
        if (SkillBut3.active)
        {
            var cd = (cdSkill3 - _rNum) + 1;
            skill3_TxtCd.text = cd.ToString();
        }
        if (SkillBut4.active)
        {
            var cd = (cdSkill4 - _rNum) + 1;
            skill4_TxtCd.text = cd.ToString();
        }
    }

}
