using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MusicManager musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (musicManager)
        {
            Debug.Log("Found music manager" + musicManager);
            Debug.Log("Volume currently set at " + PlayersPreferencesManager.GetMasterVolume());
            musicManager.ChangeVolume(PlayersPreferencesManager.GetMasterVolume());
        }
        else {
            Debug.LogWarning("No music manager found");
        }
    
        

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
