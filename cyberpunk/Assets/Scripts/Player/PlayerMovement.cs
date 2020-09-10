using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character_Controller;

    private Vector3 player_Move_Direction;

    public float speed = 3f;
    public float gravity = 20f;

    public float jump_Force = 10f;
    private float vertical_Velocity;

    private float turnSpeed = 1.5f;


    private Animator animator;



    void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
        playerAnimation();



    }

    // Moves the player
    void MoveThePlayer()
    {
        player_Move_Direction = new Vector3(Input.GetAxis("Horizontal"),
            0f, Input.GetAxis("Vertical"));

        player_Move_Direction = transform.TransformDirection(player_Move_Direction);

        if (player_Move_Direction.magnitude > 0)
        {
            Quaternion newDirection = Quaternion.LookRotation(player_Move_Direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);

        }

        player_Move_Direction *= speed * Time.deltaTime;

        Gravity();

        //character_Controller.Move(player_Move_Direction);
        character_Controller.Move(player_Move_Direction);
    }

    void playerAnimation()
    {
        // Walking Forward Animation
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);


        }
        else if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isIdle", true);
        }
    }

    // Applies gravity to the player
    void Gravity()
    {
        if (character_Controller.isGrounded)
        {
            vertical_Velocity -= gravity * Time.deltaTime;

            PlayerJump();
        }
        else
        {
            vertical_Velocity -= gravity * Time.deltaTime;
        }

        player_Move_Direction.y = vertical_Velocity * Time.deltaTime;
    }

    void PlayerJump()
    {
        if (character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
            vertical_Velocity = jump_Force;
    }
}

