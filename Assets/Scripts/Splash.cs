using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update () {

    }
}
