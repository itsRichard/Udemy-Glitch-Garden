using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    void Start()
    {
        Debug.Log("Loaded LoadManager");
        Invoke("LoadLevelNext", autoLoadNextLevelAfter);
    }

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
        // Application.LoadLevel (name);    Deprecated for Unity 5
        SceneManager.LoadScene(name);
	}

    public void LoadLevelNext()
    {
        Debug.Log("New Level load" + name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	public void QuitRequest(){
		Debug.Log ("Quit requested");
        // Application.Quit ();
        Application.Quit();
	}

}
