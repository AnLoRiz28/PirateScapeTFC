using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movimiento
    public float moveSpeed;

    //Componentes de Unity
    public Rigidbody2D rbPlayer;

    //Salto
    public float jumpForce;
    private bool canDoubleJump;

    //Deteccion de suelo
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private bool isGrounded;

    //Animaciones del jugador
    private Animator aniPlayer;
    private SpriteRenderer theSR;

    void Start()
    {
        aniPlayer = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rbPlayer.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rbPlayer.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, whatIsGround);

        if (isGrounded)
        {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpForce);
            }
            else
            {
                if (canDoubleJump)
                {
                    rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }

            
        }

        if (rbPlayer.velocity.x < 0)
        {
            theSR.flipX = true;
        }
        else if (rbPlayer.velocity.x > 0)
        {
            theSR.flipX = false;
        }


        aniPlayer.SetFloat("moveSpeed", Mathf.Abs(rbPlayer.velocity.x));
        aniPlayer.SetBool("isGrounded", isGrounded);
    }
}
