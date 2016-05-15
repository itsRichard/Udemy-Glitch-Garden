using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackPrefabArray;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackPrefabArray) {
			if (isTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}

	void Spawn (GameObject myGameObject){
		GameObject myAttacker = Instantiate (myGameObject as GameObject);
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;

	}


	bool isTimeToSpawn(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSeconds = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		} 

		float threshold = spawnsPerSeconds * Time.deltaTime;

		return (Random.value < threshold);

	}
}
