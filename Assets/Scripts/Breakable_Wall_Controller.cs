using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class Breakable_Wall_Controller : MonoBehaviour
{
    [SerializeField] GameObject breakable_wall;
    [SerializeField] AudioClip wall_sfx;
    Scene current_scene;
    string scene_name;
    bool can_break_wall;

    private void Start()
    {
        
    }

    void Update()
    {
        // get current scene
        current_scene = SceneManager.GetActiveScene();
        scene_name = current_scene.name;

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
           if (Input.GetKeyDown(KeyCode.E) && can_break_wall && Pickaxe_Handler.collected != 0)
            {
                AudioSource.PlayClipAtPoint(wall_sfx, transform.position);
                Pickaxe_Handler.collected -= 1;
                var wall = Instantiate(breakable_wall, transform.position, transform.rotation);
                gameObject.SetActive(false);
                Destroy(wall, 3f);
            }
        }
        else if (scene_name == "Level_2_Parreno")
        {
            if (Input.GetKeyDown(KeyCode.E) && can_break_wall && Pickaxe_Handler.collected != 0)
            {
                AudioSource.PlayClipAtPoint(wall_sfx, transform.position);
                Pickaxe_Handler.collected -= 1;
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
