using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD_Handler : MonoBehaviour
{

    [SerializeField] TMP_Text pickaxe_text;
    [SerializeField] TMP_Text level_timer;
    [SerializeField] GameObject pickaxe_overlay;
    [SerializeField] GameObject gameOver_overlay;
    [SerializeField] GameObject gameWin_overlay;
    public static float timer;
    public static int playTime_Counter;
    Scene current_scene;
    string scene_name;
    public static int scene_index;
    public static bool winner;

    private void Update()
    {
        // get current scene
        current_scene = SceneManager.GetActiveScene();
        scene_name = current_scene.name;
        scene_index = current_scene.buildIndex;

        pickaxe_text.SetText("X " + Pickaxe_Handler.collected);

        LevelMechanicsHandler();
    }

    void LevelMechanicsHandler()
    {
        // ======================= LEVEL 1 ======================= 
        if (scene_name == "Level_1_Cifra")
        {
            StartLevelTimer();
            GameOver();
        }

        // ======================= LEVEL 2 ======================= 
        else if (scene_name == "Level_2_Parreno")
        {
            StartLevelTimer();
            GameOver();
        }

        // ======================= LEVEL 3 ======================= 
        else if (scene_name == "Level_3_Perucho")
        {
            StartLevelTimer();
            GameOver();
            Win();
        }
    }

    void GameOver()
    {
        if (timer <= 0)
        {
            timer = 0;
            gameOver_overlay.SetActive(true);
            ResetTotalPlaytime();
            GameOverControls();
        }
        else
            gameOver_overlay.SetActive(false);
    }
    public void Win()
    {
        if (winner)
        {
            gameWin_overlay.SetActive(true);
            ResetTotalPlaytime();
            GameOverControls();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void ResetTotalPlaytime()
    {
        playTime_Counter = 0;
    }

    void GameOverControls()
    {
        AudioListener.volume = 0;
        Player_Controller.isGameOver = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void StartLevelTimer()
    {
        // pickaxe mechanic
        pickaxe_overlay.SetActive(true);

        // timer handler
        timer -= Time.deltaTime;
        float timer_to_seconds = Mathf.FloorToInt(timer);
        level_timer.SetText("TIME REMAINING: " + timer_to_seconds);
    }
}
