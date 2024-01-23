using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class Breakable_Wall_Controller : MonoBehaviour
{
    [SerializeField] GameObject breakable_wall;
    Scene current_scene;
    String scene_name;
    bool can_break_wall;

    private void Start()
    {
        current_scene = SceneManager.GetActiveScene();
        scene_name = current_scene.name;
    }

    void Update()
    {
        BreakWall();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered Collision with Player!");
            can_break_wall = true;
        }
    }

    void BreakWall()
    {
        if (scene_name == "Level_1_Cifra")
        {
            Debug.Log("Scene Level 1");
        }
        else if (scene_name == "Level_2_Parreno")
        {
            if (Input.GetKeyDown(KeyCode.E) && can_break_wall)
            {
                Debug.Log("Pressed A Key!!!");
                var wall = Instantiate(breakable_wall, transform.position, transform.rotation);
                gameObject.SetActive(false);
                Destroy(wall, 3f);
            }
        }
        else if (scene_name == "Level_3_Perucho")
        {
            Debug.Log("Scene Level 3");
        }

    }
}
