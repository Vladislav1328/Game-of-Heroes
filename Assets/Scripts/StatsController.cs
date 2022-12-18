using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    [SerializeField] private Text heroClass;
    [SerializeField] private Text heroHP;
    [SerializeField] private Text heroConsumble;
    [SerializeField] private Text heroPatk;
    [SerializeField] private Text heroPdef;
    [SerializeField] private Text heroMatk;
    [SerializeField] private Text heroMdef;
    [SerializeField] private Player player;
    [SerializeField] private Text lvlUpheroHP;
    [SerializeField] private Text lvlUpheroPatk;
    [SerializeField] private Text lvlUpheroPdef;
    [SerializeField] private Text lvlUpheroMatk;
    [SerializeField] private Text lvlUpheroMdef;


    private void Update()
    {
        SetFields();
    }

    private void SetFields()
    {
        heroClass.text = "Class: " + player.heroName;
        heroHP.text = "HP: " + player.heroHP;
        heroConsumble.text = "Consumble type: " + player.consumble.ToString();
        heroPatk.text = "p.Atk: " + player.pAtk;
        heroPdef.text = "p.Def: " + player.pDef;
        heroMatk.text = "m.Atk: " + player.mAtk;
        heroMdef.text = "m.Def: " + player.mDef;

        lvlUpheroHP.text = "+ (" + player.lvlupHP + ")";
        lvlUpheroPatk.text = "+ (" + player.lvlupPatk + ")";
        lvlUpheroPdef.text = "+ (" + player.lvlupPdef + ")";
        lvlUpheroMatk.text = "+ (" + player.lvlupMatk + ")";
        lvlUpheroMdef.text = "+ (" + player.lvlupMdef + ")";
    }
}
