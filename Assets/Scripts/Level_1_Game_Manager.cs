using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Level_1_Game_Manager : MonoBehaviour
{
    [SerializeField] GameObject controls_overlay;
    bool overlayOn;
    float time_scale;
    void Start()
    {
        // resets variables needed for level 1
        Debug.Log("Entered Game Level 1");
        AudioListener.volume = 1;
        Player_Controller.isGameOver = false;
        HUD_Handler.timer = 90;
        controls_overlay.SetActive(true);
        overlayOn = true;
        time_scale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            overlayOn = !overlayOn;
            controls_overlay.SetActive(overlayOn);

            time_scale = time_scale == 1 ? 0 : 1;
            Debug.Log(time_scale);
            Time.timeScale = time_scale;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
