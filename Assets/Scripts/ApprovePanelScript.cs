using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApprovePanelScript : MonoBehaviour
{
    //В скрипте содержится описание скилла, должен содержать все его поля. пока-что только 3. Рсход маны, треб. ур и тд. нужно добавить
    public Text skillName;
    public Text ScillDescription;
    public Image skillIcon;
    public bool skillIsChoosen = false;



    public void SkillCondition()
    {
        skillIsChoosen = true;
    }


}
