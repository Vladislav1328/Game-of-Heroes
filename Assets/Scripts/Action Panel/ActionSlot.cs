using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSlot : MonoBehaviour, IActionSlot
{
    public ActionSlotsType slotType { get; set; }

    // ��� ��������� ������� �����. �������������� �� �������, ������� � ����� ������� (� ����������� �� ����. �����).
    //public Paladin paladin;
    //public Image thisImg;


    void Start()
    {
        //thisImg.sprite = paladin.autiattack_IMG.sprite;
    }
    void Update()
    {
        
    }
}
