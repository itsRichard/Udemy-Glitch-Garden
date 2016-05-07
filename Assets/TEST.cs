using UnityEngine;
using System.Collections;

public class TEST : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print(PlayersPreferencesManager.GetMasterVolume ());
		PlayersPreferencesManager.SetMasterVolume (0.3f);
		print(PlayersPreferencesManager.GetMasterVolume ());
		print (PlayersPreferencesManager.IsLevelUnlocked(2));
		PlayersPreferencesManager.UnlockLevel (2);
		print (PlayersPreferencesManager.IsLevelUnlocked (2));

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
