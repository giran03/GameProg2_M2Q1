using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    Vector3 playerVelocity;
    CharacterController characterController;
    bool grounded;
    public static bool isGameOver;
    public static bool canMove;
    AudioSource player_footsteps_sfx;
    (Vector3, Quaternion) respawn_position;

    [Header("Configs")]
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] float gravityValue;
    [SerializeField] KeyCode jump_key = KeyCode.Space;
    [SerializeField] KeyCode flip_key = KeyCode.R;
    [SerializeField] KeyCode restart_key = KeyCode.J;
    [SerializeField] KeyCode mainMenu_key = KeyCode.H;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        var rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.cyan);

        respawn_position = (transform.position, transform.rotation);

        canMove = true;
        player_footsteps_sfx = GetComponent<AudioSource>();
        player_footsteps_sfx.volume = .6f;

        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    void Update()
    {
        Keybinds();
        MovePlayer();
        WorldBounds();
    }

    void Keybinds()
    {
        if(Input.GetKeyDown(flip_key))
            transform.Rotate(0,transform.rotation.y-180,0);
        if(Input.GetKeyDown(restart_key))
            SceneManager.LoadScene(1);
        if(Input.GetKeyDown(mainMenu_key))
            SceneManager.LoadScene(0);
    }

    void MovePlayer()
    {
        if(!canMove) return;

        grounded = characterController.isGrounded;

        Vector3 move = new(0, 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);

        if (Input.GetKeyDown(jump_key) && grounded)
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3f * gravityValue);

        if (grounded && playerVelocity.y < 0)
            playerVelocity.y = -1f;
        else
            playerVelocity.y += gravityValue * Time.deltaTime;

        // player rotation
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

        if (isGameOver) return;

        PlayerSFX();
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