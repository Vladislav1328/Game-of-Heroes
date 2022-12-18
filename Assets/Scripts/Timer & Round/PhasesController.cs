using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasesController : MonoBehaviour
{
    public GameObject phaseI;
    public GameObject phaseII;
    public TimerController timerController;

    private void Update()
    {
        RPCheck();
    }

    //Отслеживает состояние фаз текущего раунда из скрипта TimerController
    //Если активна фаза 1 - включает зеленый фонарик и наоборот
    private void RPCheck()
    {
        if (timerController.PhaseI_isActive)
            phaseI.SetActive(true);
        else
            phaseI.SetActive(false);
        if (timerController.PhaseII_isActive)
            phaseII.SetActive(true);
        else
            phaseII.SetActive(false);
    }
}
