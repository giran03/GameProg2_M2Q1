using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Level_2_Game_Manager : MonoBehaviour
{
    void Start()
    {
        // resets variables needed for level 2
        Debug.Log("Entered Game Level 2");
        HUD_Handler.timer = 180;
    }
}
