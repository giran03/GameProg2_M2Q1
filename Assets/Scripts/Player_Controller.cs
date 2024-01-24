using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Vector3 playerVelocity;
    CharacterController characterController;
    bool grounded;
    AudioSource player_footsteps_sfx;

    [Header("Configs")]
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] float gravityValue;
    (Vector3, Quaternion) respawn_position;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        var rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.cyan);

        player_footsteps_sfx = GetComponent<AudioSource>();
        player_footsteps_sfx.volume = .6f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        respawn_position = (transform.position, transform.rotation);
    }

    void Update()
    {
        MovePlayer();
        PlayerSFX();
        WorldBounds();
    }

    void MovePlayer()
    {
        grounded = characterController.isGrounded;

        Vector3 move = new(0, 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3f * gravityValue);

        if (grounded && playerVelocity.y < 0)
            playerVelocity.y = -1f;
        else
            playerVelocity.y += gravityValue * Time.deltaTime;

        // player rotation
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

        characterController.Move(playerVelocity * Time.deltaTime + movementSpeed * Time.deltaTime * move);
    }

    void PlayerSFX()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            player_footsteps_sfx.Play();
        }
        else if (Input.GetButtonUp("Vertical"))
        {
            player_footsteps_sfx.Stop();
        }

    }

    public void TeleportPlayer(Vector3 position, Quaternion rotation)
    {
        transform.SetPositionAndRotation(position, Quaternion.Euler(rotation.eulerAngles));
        Physics.SyncTransforms();
    }
    public void RespawnPlayer()
    {
        var (position, rotation) = respawn_position;
        TeleportPlayer(position, rotation);
    }

    void WorldBounds()
    {
        if (transform.position.y < -50)
        {
            RespawnPlayer();
        }
    }

}