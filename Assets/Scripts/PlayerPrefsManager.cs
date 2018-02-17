using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFICULTY_KEY = "dificulty";
    const string LEVEL_KEY = "level_unlocked_";
    
    public static void SetMasterVolume(float volume)
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if(level <= Application.levelCount - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level, 1); 
            // 1 for true
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }

    public static bool isLevelUnlocked(int level)
    {
        if (level <= Application.levelCount - 1)
        {
            if (PlayerPrefs.GetInt(LEVEL_KEY + level) == 1)
            {
                return true;
            }
        }
        else
        {
            Debug.LogError("Trying to query level not in build order");

        }
        return false;

    }

    public static void SetDificulty(float dificulty)
    {
        if(dificulty >= 1 && dificulty <= 0)
        PlayerPrefs.SetFloat(DIFICULTY_KEY, dificulty);
        else
        {
            Debug.LogError("Trying to set dificulty out of range");
        }
    }

    public static float GetDificulty()
    {
        return PlayerPrefs.GetFloat(DIFICULTY_KEY);
    }

}
