using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 11f;
    [SerializeField] float padding = 0.6f;
    [SerializeField] int health = 200;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] GameObject laserPrefabSide;
    [SerializeField] float projectileSpeed = 12f;
    [SerializeField] float projectileFiringPerion = 0.1f;
    [SerializeField] AudioClip shootSoundEffect;
    [SerializeField] AudioClip dieSoundEffect;
    [SerializeField] float shootVolume = 0.2f;
    [SerializeField] float dieVolume = 1;
    float xMin, yMin;
    float xMax, yMax;

    Coroutine firingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player collided with " + other.gameObject);
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    public int GetHealth()
    {
        return health;
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
        AudioSource.PlayClipAtPoint(dieSoundEffect, transform.position);
        Destroy(gameObject);
        FindObjectOfType<Level>().LoadGameOver();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            var laserPosition1 = transform.position;
            var laserPosition2 = transform.position;
            var laserPosition3 = transform.position;
            laserPosition1.x -= padding;
            laserPosition2.x += 0;
            laserPosition3.x += padding;
            GameObject laserBullet1 = Instantiate(
                laserPrefabSide,
                laserPosition1,
                Quaternion.identity) as GameObject;
            GameObject laserBullet2 = Instantiate(
                laserPrefab,
                laserPosition2,
                Quaternion.identity) as GameObject;
            GameObject laserBullet3 = Instantiate(
                laserPrefabSide,
                laserPosition3,
                Quaternion.identity) as GameObject;
            laserBullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, projectileSpeed);
            laserBullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            laserBullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(+2, projectileSpeed);
            AudioSource.PlayClipAtPoint(shootSoundEffect, Camera.main.transform.position, shootVolume);
            yield return new WaitForSeconds(projectileFiringPerion);
        }
    }

    private void Move() 
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        float xScale = transform.lossyScale.x / 2;
        float yScale = transform.lossyScale.y / 2;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xScale;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xScale;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yScale;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yScale;

        Debug.Log("xMin " + xMin);
        Debug.Log("xMax " + xMax);
    }
}
