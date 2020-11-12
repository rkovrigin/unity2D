using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip pickUpSound;
    [SerializeField] int score = 50;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(PickUpCoin());
        Destroy(gameObject);
    }

    IEnumerator PickUpCoin()
    {
        FindObjectOfType<GameSession>().ProcessPickUpCoin(score);
        AudioSource.PlayClipAtPoint(pickUpSound, Camera.main.transform.position);
        yield return new WaitForSeconds(1);
    }
}
