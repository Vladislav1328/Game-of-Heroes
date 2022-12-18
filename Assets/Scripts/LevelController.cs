using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private RoundNumber rNumber;
    [SerializeField] private Text lvlTxt;
    private int _level = 1;
    private int _rNum = 1;

    private void Update()
    {
        LevelUP();
        LevelPrint();
    }

    //метод провер€ет лок. переменную с значением раунда из RoundNumber
    //в методе выполн€етс€ все, что должно быть исполнено 1 раз, при повышении уровн€
    private void LevelUP()
    {
        if (_rNum != rNumber.roundNumber)
        {
            _rNum = rNumber.roundNumber;
            _level = rNumber.roundNumber;
            player.LevelUP();
        }
    }

    //¬ывод значение уровн€ в юи тхт
    private void LevelPrint()
    {
        lvlTxt.text = _level.ToString();
    }


}

