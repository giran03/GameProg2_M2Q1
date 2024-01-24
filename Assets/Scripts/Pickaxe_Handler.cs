using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pickaxe_Handler : MonoBehaviour
{
    public static int collected;


    void Start()
    {
        collected = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            collected += 1;
            gameObject.SetActive(false);
            Debug.Log("Picked up a pickaxe");
        }
    }
}
