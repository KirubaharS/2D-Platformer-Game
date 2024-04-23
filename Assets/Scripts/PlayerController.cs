using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;

    private Rigidbody2D playerBody;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void PlayerWalk ()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal > 0) {
            playerBody.velocity = new Vector2(speed, playerBody.velocity.y);
        } else if (horizontal < 0) {
            playerBody.velocity = new Vector2(-speed, playerBody.velocity.y);
        }
        //PlayMovementAnimation(horizontal, vertical);
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);

    }

    private void MoveCharacter(float horizontal, float vertical)
    {        
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
          
        
        if (vertical > 0 ) 
        {
            playerBody.AddForce(new Vector2 (0f, jump), ForceMode2D.Force);
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



}
