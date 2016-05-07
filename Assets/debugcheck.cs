using UnityEngine;
using System.Collections;

public class debugcheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("The difficulty is " + PlayersPreferencesManager.GetDifficulty ()); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
