using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float loadDelay = 1f;
    [SerializeField] float levelExitSlowMore = 0.2f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNewLevel(loadDelay));
    }

    IEnumerator LoadNewLevel(float delay)
    {
        Time.timeScale = levelExitSlowMore;
        yield return new WaitForSeconds(delay);
        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
