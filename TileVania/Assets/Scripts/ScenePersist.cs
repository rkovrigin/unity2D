using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    int startingBuildIndex;

    private void Awake()
    {
        int numScenePersists = FindObjectsOfType<ScenePersist>().Length;

        if (numScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startingBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }


    // Update is called once per frame
    void Update()
    {
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (startingBuildIndex != currentSceneBuildIndex)
        {
            Destroy(gameObject);
        }
    }
}
