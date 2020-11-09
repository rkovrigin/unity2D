using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;

    //State
    bool isAlive = true;

    //Cached
    Animator animator;
    Rigidbody2D myRigidBody;
    Collider2D collider2D;

    //Consts
    const string STATE_RUN = "Running";
    const string STATE_CLIMB = "Climbing";

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        SwitchAnimation();
        Jump();
        ClimbLadder();
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // from -1 to +1
        if (myRigidBody)
        {
            Vector2 playerVelocity = new Vector2(
                controlThrow * runSpeed,
                myRigidBody.velocity.y);
            myRigidBody.velocity = playerVelocity;
        }
    }

    private void ClimbLadder()
    {
        if (!collider2D.IsTouchingLayers(LayerMask.GetMask("Ladder"))) { return; }

        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical"); // from -1 to +1
        Vector2 climbVelocity = new Vector2(
            myRigidBody.velocity.x,
            controlThrow * climbSpeed);
        myRigidBody.velocity = climbVelocity;
        bool playerHadVelocitySpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        animator.SetBool(STATE_CLIMB, playerHadVelocitySpeed);
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector3(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    private void SwitchAnimation()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        animator.SetBool(STATE_RUN, playerHasHorizontalSpeed);
    }

    private void Jump()
    {
        if (!collider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
        }
    }
}
