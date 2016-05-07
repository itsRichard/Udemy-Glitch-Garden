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


}
