using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Handler : MonoBehaviour
{
    Scene current_scene;
    string scene_name;
    int scene_index;

    private void Update()
    {
        // get current scene
        current_scene = SceneManager.GetActiveScene();
        scene_name = current_scene.name;
        scene_index = current_scene.buildIndex;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Next Scene!");
            NextLevel();
        }
    }

    void NextLevel()
    {
        if(scene_name != "Level_3_Perucho")
            SceneManager.LoadScene(scene_index + 1);
        else
            Debug.Log("Congrats!");
    }
}
