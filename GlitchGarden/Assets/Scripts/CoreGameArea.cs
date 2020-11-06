using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGameArea : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        if (!defender)
            return;
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rowCoord)
    {
        rowCoord.x = Mathf.RoundToInt(rowCoord.x);
        rowCoord.y = Mathf.RoundToInt(rowCoord.y);
        return rowCoord;
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defender, roundedPos, transform.rotation) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }
}
