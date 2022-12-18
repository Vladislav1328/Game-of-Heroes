using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BDBSlot : MonoBehaviour
{
    //Скрипт баф\дебаф слота, содержиит поля, нужные для отображения длительности активности эффекта
    //значение длительности минусуется и регуллируется внутри этог оскрипта а устанавливается внутри плеер скрипта

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
        durationTXT.text = duration.ToString(); //постоянный вывод значения длительности в тхт 
    }

    //обновление значения таймера и, если слот был заюзан - обновляет его длительность
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
