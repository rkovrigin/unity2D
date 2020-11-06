using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "MaterVolume";
    const string DIFFICULTY_KEY = "DifficultyKey";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("Set new volume " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty % 1 > 0) return;
        Debug.Log("Set new difficulty " + difficulty);
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
