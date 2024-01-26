using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_Game_Manager : MonoBehaviour
{
    void Start()
    {
        // resets variables needed for level 2
        Debug.Log("Entered Game Level 3");
        HUD_Handler.timer = 240;
    }
}
