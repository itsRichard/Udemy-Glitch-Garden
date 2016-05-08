using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;

	// Use this for initialization

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }
	void Awake () {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Not destroying onLoad :" + name);
        //AudioSource.PlayClipAtPoint(levelMusicChangeArray[SceneManager.GetActiveScene().buildIndex],transform.position);
    }

    void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        Debug.Log("Playing clip " + thisLevelMusic);
        if (thisLevelMusic)
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

	public void ChangeVolume (float vol)
	{
		audioSource.volume = vol;
	}

	// Update is called once per frame
	void Update () {
    }
}
