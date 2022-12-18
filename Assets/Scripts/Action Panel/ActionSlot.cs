using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSlot : MonoBehaviour, IActionSlot
{
    public ActionSlotsType slotType { get; set; }

    // для установки спрайта слото. устанавливатет то тспрайт, который в плеер скрипте (в зависимости от выбр. перса).
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
