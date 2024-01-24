using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_2_Game_Manager : MonoBehaviour
{
    void Start()
    {
        // resets variables needed for level 2
        Debug.Log("Entered Game Level 2");
        HUD_Handler.timer = 10;
    }

    void Update()
    {
        if (HUD_Handler.timer <= 0)
        {
            HUD_Handler.timer = 1;
            Debug.Log("GAME OVER!");
        }
    }
}
