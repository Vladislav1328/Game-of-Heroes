using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ApprovePanelController : MonoBehaviour
{
    public ApprovePanelScript pan1;
    public ApprovePanelScript pan2;
    public ApprovePanelScript pan3;
    public ApprovePanelScript pan4;

    public GameObject firstButtonsP1;
    public GameObject nextButtonsP1;
    public GameObject firstButtonsP2;
    public GameObject nextButtonsP2;
    public GameObject firstButtonsP3;
    public GameObject nextButtonsP3;
    public GameObject firstButtonsP4;
    public GameObject nextButtonsP4;

    public Player player;
    public Image butAutoattackIMG;
    public Image but1IMG;
    public Image but2IMG;
    public Image but3IMG;
    public Image but4IMG;
    public Paladin paladin;
    public Warrior warrior;

    private int _rNum;
    public RoundNumber roundNum;

    private void Start()
    {
        _rNum = roundNum.roundNumber;
    }
    private void Update()
    {

        SetClassInfo();
        CheckChoosenSkill();
        RoundNumberCheck();
    }
    //��������� ������ ������� ���������� ������ � ������ � �������
    private void IconsSet()
    {
        pan1.skillIcon.sprite = but1IMG.sprite;
        pan2.skillIcon.sprite = but2IMG.sprite;
        pan3.skillIcon.sprite = but3IMG.sprite;
        pan4.skillIcon.sprite = but4IMG.sprite;
    }

    //��������� ����� � �������� ������� �� ������� �������� � ���� �������
    private void PaladinsSkills()
    {
        pan1.skillName.text = paladin.skill1Name;
        pan2.skillName.text = paladin.skill2Name;
        pan3.skillName.text = paladin.skill3Name;
        pan4.skillName.text = paladin.skill4Name;
        pan1.ScillDescription.text = paladin.skill1Descript;
        pan2.ScillDescription.text = paladin.skill2Descript;
        pan3.ScillDescription.text = paladin.skill3Descript;
        pan4.ScillDescription.text = paladin.skill4Descript;
    }
    private void WarriorsSkills()
    {
        pan1.skillName.text = warrior.skill1Name;
        pan2.skillName.text = warrior.skill2Name;
        pan3.skillName.text = warrior.skill3Name;
        pan4.skillName.text = warrior.skill4Name;
        pan1.ScillDescription.text = warrior.skill1Descript;
        pan2.ScillDescription.text = warrior.skill2Descript;
        pan3.ScillDescription.text = warrior.skill3Descript;
        pan4.ScillDescription.text = warrior.skill4Descript;
    }

    //��������� ����������� ������
    private void SetClassInfo()
    {
        //�������� �� ��, ������ �� ��� �����-���� �����
        if (player.heroIsChoosen == true)
        {
            //��������� ������ ����.������ � ������ ������ �������
            IconsSet();

            //�������� �� ��, ����� ������ ������ �����
            //���������� ����� ��������� �������� �� ������ �� �������
            if (player.choosenHero.name == "Paladin")
            {
                //��������� ��������� ������������� ���� � �������� � ���������� ������� �������
                PaladinsSkills();
            }
            if (player.choosenHero.name == "Warrior")
            {
                WarriorsSkills();
            }
        }
    }

    //�������� �� ��, ������ �� ��� �����-���� �����. ���� ��, �� ������
    //������ (������ � �������) � ������� ������ �������
    private void CheckChoosenSkill()
    {
        if (pan1.skillIsChoosen || pan2.skillIsChoosen || pan3.skillIsChoosen || pan4.skillIsChoosen == true)
        {
            ButtonsPhasesChange();
        }
    }

    //����� ���������� ������ ������ ���� � ��������� ������
    private void ButtonsPhasesChange()
    {
        firstButtonsP1.SetActive(false);
        firstButtonsP2.SetActive(false);
        firstButtonsP3.SetActive(false);
        firstButtonsP4.SetActive(false);
        nextButtonsP1.SetActive(true);
        nextButtonsP2.SetActive(true);
        nextButtonsP3.SetActive(true);
        nextButtonsP4.SetActive(true);
    }

    //����� ���������� ������ ������ ���� � ��������� ������
    private void ButtonsPhasesReset()
    {
        firstButtonsP1.SetActive(true);
        firstButtonsP2.SetActive(true);
        firstButtonsP3.SetActive(true);
        firstButtonsP4.SetActive(true);
        nextButtonsP1.SetActive(false);
        nextButtonsP2.SetActive(false);
        nextButtonsP3.SetActive(false);
        nextButtonsP4.SetActive(false);
    }
     
    //�������� �� ��������� ������. ��� ��������� - � ���� ������ ������������ ���� ������ � �������
    private void RoundNumberCheck()
    {
        if (_rNum != roundNum.roundNumber)
        {
            //����� ������
            ButtonsPhasesReset();
            //���� ��������� � �������
            pan1.skillIsChoosen = false;
            pan2.skillIsChoosen = false;
            pan3.skillIsChoosen = false;
            pan4.skillIsChoosen = false;

            _rNum = roundNum.roundNumber; 
        }
    }    
}
