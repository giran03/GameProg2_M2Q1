using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Teleporter_Handler : MonoBehaviour
{
    [SerializeField] Transform linked_destination;
    [SerializeField] AudioClip teleport_sfx;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.TryGetComponent<Player_Controller>(out var player))
        {
            AudioSource.PlayClipAtPoint(teleport_sfx, linked_destination.transform.position);
            player.TeleportPlayer(linked_destination.transform.position, linked_destination.rotation);
        }
    }
}
