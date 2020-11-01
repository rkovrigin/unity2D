using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    TextMeshProUGUI healthText;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = Mathf.Max(0, player.GetHealth()).ToString();
    }
}
