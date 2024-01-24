using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD_Handler : MonoBehaviour
{

    [SerializeField] TMP_Text pickaxe_text;
    [SerializeField] TMP_Text level_timer;
    [SerializeField] GameObject pickaxe_mechanics;
    Scene current_scene;
    String scene_name;
    public static float timer;

    private void Update()
    {
        // get current scene
        current_scene = SceneManager.GetActiveScene();
        scene_name = current_scene.name;

        pickaxe_text.SetText("X " + Pickaxe_Handler.collected);

        LevelMechanicsHandler();
    }

    void LevelMechanicsHandler()
    {
        // ======================= LEVEL 1 ======================= 
        if (scene_name == "Level_1_Cifra")
        {
            Debug.Log("Scene Level 1");
            pickaxe_mechanics.SetActive(false);
        }

        // ======================= LEVEL 2 ======================= 
        else if (scene_name == "Level_2_Parreno")
        {
            // pickaxe mechanic
            pickaxe_mechanics.SetActive(true);

            // timer handler
            timer -= Time.deltaTime;
            float timer_to_seconds = Mathf.FloorToInt(timer);
            level_timer.SetText("TIME REMAINING: " + timer_to_seconds);
        }

        // ======================= LEVEL 3 ======================= 
        else if (scene_name == "Level_3_Perucho")
        {
            Debug.Log("Scene Level 3");
            pickaxe_mechanics.SetActive(false);
        }
    }

}
