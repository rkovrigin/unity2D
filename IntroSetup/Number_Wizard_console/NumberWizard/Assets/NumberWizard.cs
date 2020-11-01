using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int max = 1000;
    int min = 1;
    int guess = 500;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello to Number Wizard!");
        Debug.Log("Pick any number from " + min + " to " + max);
        Debug.Log("Push UP if it is higher, push DOWN if it is lower");
        Debug.Log("I guess " + guess);
        max = max + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            guess = (min + max) / 2;
            Debug.Log("Guess " + guess);
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            guess = (min + max) / 2;
            Debug.Log("Guess " + guess);
        } else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("I guessed " + guess);
        }
    }
}
