using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    CoreGameArea coreGameArea;

    private void Start()
    {
        coreGameArea = FindObjectOfType<CoreGameArea>();
        LabelNumberWithCost();
    }

    private void LabelNumberWithCost()
    {
        Text textCost = GetComponentInChildren<Text>();
        if (textCost)
        {
            textCost.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        SetAllButtonsBlack();
        GetComponent<SpriteRenderer>().color = Color.white;
        coreGameArea.SetSelectedDefender(defenderPrefab);
    }

    private void SetAllButtonsBlack()
    {
        foreach(DefenderButton button in FindObjectsOfType<DefenderButton>())
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }
    }
}
