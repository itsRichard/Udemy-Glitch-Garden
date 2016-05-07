using UnityEngine;
using System.Collections;

public class PlayersPrefManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    // level_unlocked_1...n

        // public = everything needs to access it
        // static = there's only one of these things 
        // void = doesn't have to return anything 
    public static void SetMasterVolume (float volume){
        if (volume > 0f && volume < 1f) { 
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range: " + volume);
        }
    }

    public static float GetMasterVolume ()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel (int level)
    {
        if (level <= Application.levelCount - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // use 1 for true because we don't have bools
        } else
        {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }

    public static bool IsLevelUnlocked (int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()); // returns 0, nothing, or 1
        bool isLevelUnlocked = (levelValue == 1);   // unlocked yes or no
        if (level <= Application.levelCount - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Trying to query level not in the build order");
            return false;
        }
    }

    public static void SetDifficulty (float difficulty)
    {
        if (difficulty >= 0f && difficulty <= 1f)
        {
            // do it
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
