using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D enemyBody;
    public Animator animator;
    private bool moveRight;
    public Transform down_collision;


    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void Start()
    {
        moveRight = true;
    }

    private void Update()
    {
        if (moveRight)
        {
            enemyBody.velocity = new Vector2(moveSpeed, enemyBody.velocity.y);
        }
        else
        {
            enemyBody.velocity = new Vector2(-moveSpeed, enemyBody.velocity.y);
        }
        CheckCollision();
    }

    void CheckCollision()
    {
        if(!Physics2D.Raycast(down_collision.position, Vector2.down, 0.1f))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        moveRight = !moveRight;
        Vector3 tempscale = transform.localScale;
        if (moveRight) {
            tempscale.x = Mathf.Abs(tempscale.x);
        } else
        {
            tempscale.x = -Mathf.Abs(tempscale.x);
        }
        transform.localScale = tempscale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
        }
    }
}
