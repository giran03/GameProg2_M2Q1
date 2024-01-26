using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Handler : MonoBehaviour
{
    private void Start()
    {
        HUD_Handler.winner = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("Game Quit! Thank you for playing! ;D");
        Application.Quit();
    }
}
