using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Teleporter_Handler : MonoBehaviour
{
    [SerializeField] Transform linked_destination;


    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player") && other.TryGetComponent<Player_Controller>(out var player))
        {
            player.TeleportPlayer(linked_destination.transform.position, linked_destination.rotation);
        }
    }

}
