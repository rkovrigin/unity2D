using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currentSceneIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScreen());
        }
    }

    IEnumerator LoadStartScreen()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
