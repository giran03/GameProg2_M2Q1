using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1_Game_Manager : MonoBehaviour
{
    void Start()
    {
        // resets variables needed for level 1
        Debug.Log("Entered Game Level 1");
        AudioListener.volume = 1;
        Player_Controller.isGameOver = false;
        HUD_Handler.timer = 90;
    }
}
