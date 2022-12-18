using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPMPBarController : MonoBehaviour
{
    public Text p1HP;
    public Player player;

    private void Update()
    {
        p1HP.text = "HP: " + player.heroHP.ToString();
    }
}
