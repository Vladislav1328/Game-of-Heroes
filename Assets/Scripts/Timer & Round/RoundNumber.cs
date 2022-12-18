using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundNumber : MonoBehaviour
{
    //СМЕНА РАУНДА ПРОИСХОДИТ В СКРИПТЕ TimerController (МЕТОД TimersCheck)
  
    public int roundNumber { get; set; } = 1;
    public bool condition { get; set; } = false;
    public TimerController timerController;
    private Text roundNumTXT;

    private void Start()
    {
        roundNumTXT = this.GetComponent<Text>();
    }

    private void Update()
    {
        RoundNumberPrint();
    }
    
    //Выводит значание раунда в ТХТ
    private void RoundNumberPrint()
    {
        roundNumTXT.text = "Round "+Mathf.Round(roundNumber).ToString();
    }

    //Методы для отработки из скрипта TimerController: 
    //Отработка метода активирует возможность изменить значение переменной номера раунда
    public void RoundConditionSet()
    {
        condition = true;
    }

    //Меняет значение номера раунда 
    public void RoundPlus()
    {
        if (condition)
            roundNumber++;
            condition = false;
    }
}
