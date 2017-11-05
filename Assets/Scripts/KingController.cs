using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingController : MonoBehaviour {

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float jumpHeight = 6f;

    private bool isOnGround;
    private bool isOnWall;
    private Rigidbody2D myRigidBody2D;
    bool facingRight = true;
    Animator anim;

    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    
    public Transform wallCheck;
    float wallRadius = 0.2f;
    public LayerMask whatIsWall;

    private AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
        isOnWall = true;
    }


    // Use this for initialization
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();

        // [SerializeField] put above a private variable to
        // allow it to show up in unity editor, yet keep it private

        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            myRigidBody2D.velocity =
                new Vector2(myRigidBody2D.velocity.x, jumpHeight);
            audioSource.Play();
            isOnGround = false;
        }
        else if(Input.GetButtonDown("Jump") && isOnWall)
        {
            myRigidBody2D.velocity =
                new Vector2(myRigidBody2D.velocity.x, jumpHeight);
            audioSource.Play();
        }
    }

    private void HandlePlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        myRigidBody2D.velocity =
            new Vector2(speed * horizontalInput, myRigidBody2D.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
        anim.SetFloat("jumpHeight", GetComponent<Rigidbody2D>().velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", isOnGround);

        isOnWall = Physics2D.OverlapCircle(wallCheck.position, wallRadius, whatIsWall);
        anim.SetBool("Wall", isOnWall);



        if (horizontalInput > 0 && !facingRight)
            Flip();
        else if (horizontalInput < 0 && facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}


