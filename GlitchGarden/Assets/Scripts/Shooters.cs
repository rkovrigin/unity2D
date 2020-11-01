using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooters : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerOnLane())
        {
            Debug.Log("Shoot pew pew");
            //TODO Change animation state to shoot
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            Debug.Log("Sit and wait");
            //TODO Change animation state to idle
            animator.SetBool("IsAttacking", false);
        }
    }

    private bool IsAttackerOnLane()
    {
        if (myLaneSpawner && myLaneSpawner.transform.childCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough =
                (Mathf.Abs(spawner.transform.position.y - transform.position.y)
                <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
        return;
    }
}
