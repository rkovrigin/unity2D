using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody2D;
    BoxCollider2D rightBoxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        rightBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            myRigidBody2D.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidBody2D.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player") { return; }

        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody2D.velocity.x)), 1f);
    }
}
