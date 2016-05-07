using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayersPreferencesManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";		//e.g. level_unlocked_1
	const string DIFF_KEY = "difficulty";


	public static void SetMasterVolume(float volume)
	{
		if (volume >= 0 && volume <= 1f) 
		{
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} 
		else
		{
			Debug.Log("Error setting volume");
		}
	}
	
	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel (int level){
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (),1); // use 1 for true
		} else {
			Debug.LogError ("Trying to unlock level not in the build order");
		}
	}

	public static bool IsLevelUnlocked(int level){

		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			int levelValue = PlayerPrefs.GetInt(LEVEL_KEY+level.ToString());
			// will return 1 or not
			bool isLevelUnlocked = (levelValue == 1);
			return isLevelUnlocked;

			} else {
			Debug.LogError ("Trying to query level not in the build order");
			return false;
		}

	}

	public static void SetDifficulty(float difficulty)
	{
		if (difficulty >= 0f && difficulty <= 3) {
			PlayerPrefs.SetFloat (DIFF_KEY, difficulty);
		} else {
			Debug.LogError ("Difficulty invalid");
		}
	}

	public static float GetDifficulty()
	{
		return PlayerPrefs.GetFloat (DIFF_KEY);
	}
		

	
}
