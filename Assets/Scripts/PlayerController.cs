using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public float speed;
    public float jump;

    public Transform GroundCheckPosition;
    public LayerMask GroundLayer;

    private bool isGrounded;
    private bool jumped;
    private float jumpPower = 12f;

    private Rigidbody2D playerBody;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckIfGrounded();
        PlayerJump();
    }

    private void FixedUpdate()
    {
        PlayerWalk();
        
    }

    void PlayerWalk ()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        if (horizontal > 0) {
            playerBody.velocity = new Vector2(speed, playerBody.velocity.y);
        } else if (horizontal < 0) {
            playerBody.velocity = new Vector2(-speed, playerBody.velocity.y);
        } else
        {
            playerBody.velocity = new Vector2(0f, playerBody.velocity.y);
        }
        animator.SetFloat("Speed", Mathf.Abs(playerBody.velocity.x));
        Vector3 scale = transform.localScale;
        if (horizontal < 0f)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0f)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    void CheckIfGrounded ()
    {
        isGrounded = Physics2D.Raycast(GroundCheckPosition.position, Vector2.down, 0.1f, GroundLayer);
        if(isGrounded)
        {
            if(jumped)
            {
                jumped=false;
                animator.SetBool ("Jump", false);
            }
        }
    }

    void PlayerJump ()
    {
        if(isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                jumped = true;
                playerBody.velocity = new Vector2(playerBody.velocity.x, jumpPower);
                animator.SetBool("Jump", true);
            }
        }
    }


    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0f)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0f)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        animator.SetFloat("Speed", Mathf.Abs(vertical));
        if (vertical > 0f)
        {
            animator.SetBool("Jump", true);
        } else
        {
            animator.SetBool("Jump", false);
        }

    }


    public void Crouch(bool crouch)
    {
        animator.SetBool("Crouch", crouch);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }
    }

    public void PickUpKey()
    {
        Debug.Log("Player Picked Up The Key");
        scoreController.IncreaseScore(10);
    }

    public void KillPlayer()
    {
        Debug.Log("Player Killed By The Enemy");
        ReloadLevel();
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
