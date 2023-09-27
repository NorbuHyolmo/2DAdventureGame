using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // to store the component in rb
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D boxCollider2D;
    //private CapsuleCollider2D capCollider2D;
    private float directionX = 0f;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling};

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private ParticleSystem dust;

    // Start is called before the first frame update
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        //capCollider2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame 
    private void Update()
    {
        TestingMovement();

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            //Vector3 holds 3 different values of the position(x,y,z)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
            CreateDust();
        }

        UpdateAnimationState();
    }

    private void TestingMovement()
    {
        //to use the horizonal(left,right) provided by the input settings
        directionX = Input.GetAxisRaw("Horizontal");

        //change the position of x axis
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            rb.velocity = new Vector2(directionX * movementSpeed, rb.velocity.y);
        }

    }

    private void UpdateAnimationState()
    {
        MovementState state;
        // this part is for the movement animation like flipping and idleing 
        if (directionX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
            CreateDust();
        }
        else if (directionX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
            CreateDust();
        }
        else
        {
            state = MovementState.idle;
        }

        // this part is to check if the character is jumping or falling to trigger the designated animation 
        // we have checked the condition on the y-axis for the jumping part where +ve is jump and -ve is fall 
        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
            CreateDust();
        }

        anim.SetInteger("state", (int)state);
    }


    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }



    private void CreateDust()
    {
        dust.Play();
    }
}
