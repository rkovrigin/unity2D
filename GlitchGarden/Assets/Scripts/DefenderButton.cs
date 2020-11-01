using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    CoreGameArea coreGameArea;

    private void Start()
    {
        coreGameArea = FindObjectOfType<CoreGameArea>();
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
