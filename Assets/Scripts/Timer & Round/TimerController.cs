using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public bool PhaseI_isActive { get; set; } = true;
    public bool PhaseII_isActive { get; set; } = false;

    public Timer startTimer;
    public Timer endTimer;
    public GameObject startT;
    public GameObject endT;
    public RoundNumber roundNumber;

    private void Update()
    {
        TimersCheck();
    }

    //Метод, который управляет переключением таймеров в зависимости от их значения time
    public void TimersCheck()
    {
        if (startTimer.time <= 0) //Проверка: достиг ли таймер нуля
        {
            if (startTimer.condition == true) //Проверка: активно ли у таймера состояние condition
            {
                startTimer.TimeStop();  //Выключает текущий таймер
                startT.SetActive(false); //Скрывает текущий таймер из сцены
                endTimer.TimeStart(); //Запускает енд таймер
                SetEndTime(); //Устанавливает значение в енд таймер из локального метода

                //Для функционала других механик
                //Для RoundNumber
                roundNumber.RoundConditionSet(); //Активирует возможность изменить значение переменной раунда
                PhaseIReset();
            }
        }
        if (endTimer.time <= 0)
        {
            if (endTimer.condition == true)
            {   //Реверсивные проверки по аналогии с предыдущими
                endTimer.TimeStop();
                endT.SetActive(false);
                startTimer.TimeStart();
                SetStartTime();

                //Для функционала других механик
                //Для RoundNumber
                roundNumber.RoundPlus(); //Меняет значение номера раунда (в самом конце, когда таймер уже обновляется)
                PhaseIIReset();
            }
        }
    }

    //Локлаьные методы для установки в таймеры их начальных значений 
    //Устанавливается здесь, в контроллере, а не в скрипте таймеров потому что у них 1 общий скрипт
    private void SetStartTime()
    {
        startTimer.time = 60;
        startT.SetActive(true);
    }
    private void SetEndTime()
    {
        endTimer.time = 6;
        endT.SetActive(true);
    }

    //Локальные методы для смены состояний переменных, отвечающих за Фазы 1 и 2
    //Переменные нужны для дальнейшего обращения к ним с целью узнать текущую фазу раунда
    private void PhaseIReset()
    {
        if (PhaseI_isActive == true)
        {
            PhaseI_isActive = false;
            PhaseII_isActive = true;
        }

    }
    private void PhaseIIReset()
    {
        if (PhaseII_isActive == true)
        {
            PhaseII_isActive = false;
            PhaseI_isActive = true;
        }
    }

    //Метод для вызова из кнопки енд раунда, устанавливает таймиер на 0, тем самым начиная вторую фазу раунда
    public void EndRoundButtonClick()
    {
        startTimer.time = 0;
    }

    //Метод для вызова из кнопки выбранного персонажа, запускает таймер и
    //устанавливает исходное значение (далее тамер работает автономно)
    public void ForChooseButton()
    {
        startTimer.TimeStart();
        SetStartTime();
    }
}
