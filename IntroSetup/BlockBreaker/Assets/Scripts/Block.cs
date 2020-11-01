using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakingSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    [Range(1, 10)][SerializeField] int MaxHits = 3;

    //Cached reference
    Level level;
    int life;


    private void Start()
    {
        life = MaxHits;
        CountBreakableBlocks();
        if (tag == "Breakable")
        {
            ShowNextHitSprite();
        }
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit(collision);
    }

    protected void HandleHit(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            life -= 1;
            if (life == 0)
            {
                PlayBlockDestroySFX();
                Destroy(gameObject, 0);
                level.BlockDestroyed();
                TriggerSparklesVFX();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
        Debug.Log(collision.gameObject.name);
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = life - 1;
        Debug.Log("Index [" + spriteIndex + "]");
        Debug.Log("Length [" + hitSprites.Length + "]");
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing in an array " + gameObject.name);
        }
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakingSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }


}
