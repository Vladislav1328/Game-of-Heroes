using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApprovePanelScript : MonoBehaviour
{
    //� ������� ���������� �������� ������, ������ ��������� ��� ��� ����. ����-��� ������ 3. ����� ����, ����. �� � ��. ����� ��������
    public Text skillName;
    public Text ScillDescription;
    public Image skillIcon;
    public bool skillIsChoosen = false;



    public void SkillCondition()
    {
        skillIsChoosen = true;
    }


}
