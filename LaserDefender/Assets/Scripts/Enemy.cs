using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy stats")]
    [SerializeField] float health = 100f;
    [SerializeField] int scoreValue = 50;

    [Header("Shooting")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectTileSpeed = 5f;

    [Header("Sound effects")]
    [SerializeField] GameObject explosionAnimation;
    [SerializeField] float explosionDuration = 1f;
    [SerializeField] AudioClip shootSoundEffect;
    [SerializeField] AudioClip dieSoundEffect;
    [SerializeField] float shootVolume = 0.4f;
    [SerializeField] float dieVolume = 1;

    private void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
            AudioSource.PlayClipAtPoint(shootSoundEffect, transform.position, shootVolume);
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject enemyBullet = Instantiate(
                laserPrefab,
                transform.position,
                Quaternion.identity) as GameObject;
        enemyBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectTileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddScore(scoreValue);
        AudioSource.PlayClipAtPoint(dieSoundEffect, transform.position, dieVolume);
        Destroy(gameObject);
        var explosion = Instantiate(explosionAnimation,
            transform.position,
            Quaternion.identity) as GameObject;
        Destroy(explosion, explosionDuration);
    }
}
