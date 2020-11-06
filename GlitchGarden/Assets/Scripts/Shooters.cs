using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooters : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun, projectileParent;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    const string PROJECTILE_PARENT = "Projectile";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        projectileParent = GameObject.Find(PROJECTILE_PARENT);
        if (!projectileParent)
        {
            projectileParent = new GameObject();
        }
    }

    private void Update()
    {
        if (IsAttackerOnLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
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
        GameObject prj = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        prj.transform.parent = projectileParent.transform;
        return;
    }
}
