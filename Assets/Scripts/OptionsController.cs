using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public LevelManager levelManager;
	public MusicManager musicManager;
	public Slider difficultySlider;

	// Use this for initialization
	void Start () {

		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		volumeSlider.value = PlayersPreferencesManager.GetMasterVolume ();
		difficultySlider.value = PlayersPreferencesManager.GetDifficulty ();
		print (PlayersPreferencesManager.GetMasterVolume ());
		Debug.Log (musicManager);
	
	}

	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume (volumeSlider.value);
	}

	public void SaveAndExit () {
		print ("Slider is at "+  volumeSlider.value +  " and Player Pref is at " + PlayersPreferencesManager.GetMasterVolume());
		PlayersPreferencesManager.SetMasterVolume (volumeSlider.value);
		print ("Slider is at "+  difficultySlider.value +  " and Player Pref is at " + PlayersPreferencesManager.GetDifficulty());
		PlayersPreferencesManager.SetDifficulty (difficultySlider.value);
		print ("Player Pref Volume is now set at " + PlayersPreferencesManager.GetMasterVolume());
		print ("Player Pref Difficulty is now set at " + PlayersPreferencesManager.GetDifficulty());
        levelManager.LoadStart();
	}

	public void SetDefaults(){
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2;
	}

}
