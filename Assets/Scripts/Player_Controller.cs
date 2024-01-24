using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Vector3 playerVelocity;
    private CharacterController characterController;
    private bool grounded;

    [Header("Configs")]
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] float gravityValue;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        var rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.cyan);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        grounded = characterController.isGrounded;

        Vector3 move = new(0, 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            //Debug.Log("Pressed space");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3f * gravityValue);
        }

        if (grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -1f;
        }
        else
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
        }

        // player rotation
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

        characterController.Move(playerVelocity * Time.deltaTime + movementSpeed * Time.deltaTime * move);
    }

}