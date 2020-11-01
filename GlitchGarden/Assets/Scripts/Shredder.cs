using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] Lives lives;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (lives)
        {
            Debug.Log(gameObject.name);
            lives.TakeLife();
        }
        Destroy(collision.gameObject);
    }
}
