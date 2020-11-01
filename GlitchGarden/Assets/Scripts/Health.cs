using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 40;
    [SerializeField] GameObject dieAnimation;
    [SerializeField] float dieAnimationDuration = 1f;

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
            TriggerDeathVFX();
        }
    }

    private void TriggerDeathVFX()
    {
        if (dieAnimation)
        {
            var dieAnimationObject = Instantiate(
                                        dieAnimation,
                                        transform.position,
                                        transform.rotation) as GameObject;
            Destroy(dieAnimationObject, dieAnimationDuration);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
