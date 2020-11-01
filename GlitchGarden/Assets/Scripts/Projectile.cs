using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    [SerializeField] float angle = 90f;
    [SerializeField] int damage = 10;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        if ( health && attacker)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
