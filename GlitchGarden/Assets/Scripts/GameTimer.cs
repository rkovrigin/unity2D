using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTimerInSeconds = 10;
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) return;

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTimerInSeconds;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTimerInSeconds);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
