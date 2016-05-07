using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public LevelManager levelmanager;
	public MusicManager musicManager;

	// Use this for initialization
	void Start () {

		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		Debug.Log (musicManager);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
