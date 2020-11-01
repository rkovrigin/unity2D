using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 5;
    [SerializeField] int damage = 1;
    Text livesText;

    private void Start()
    {
        livesText = GetComponent<Text>();
        UpdateScoreText();
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateScoreText();

        if (lives <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadYouLoose();
        }
    }

    private void UpdateScoreText()
    {
        livesText.text = lives.ToString();
    }
}
