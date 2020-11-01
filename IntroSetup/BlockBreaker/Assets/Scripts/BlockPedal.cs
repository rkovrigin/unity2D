using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockPedal : Block
{
    Block[] visibleBlocks;

    public void Start()
    {
        visibleBlocks = FindObjectsOfType<Block>();
    }

    public void SetVisibility()
    {
        Debug.Log("SetVisibility");
        foreach (Block block in visibleBlocks)
        {
            Debug.Log("SetVisibility block " + block + "!");
            if (block.gameObject.tag == "Breakable") {
                block.gameObject.SetActive(!block.gameObject.activeSelf);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.HandleHit(collision);
        Debug.Log("Pedal pressed");
        SetVisibility();
    }
}
