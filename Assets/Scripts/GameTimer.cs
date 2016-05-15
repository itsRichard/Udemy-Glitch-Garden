using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 100;


    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;
    // Use this for initialization
    void Start ()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        FindYouWin();
        winLabel.SetActive(false);
    }

    private void FindYouWin()
    {
        winLabel = GameObject.Find("You Win");
        if (!winLabel)
        {
            Debug.LogWarning("Please create You Win object");
        }
    }

    // Update is called once per frame
    void Update () {
        slider.value = (Time.timeSinceLevelLoad / levelSeconds);
        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            HandleWinCondition();
        }
    }

    private void HandleWinCondition()
    {
        DestroyAllTaggedObjects();
        print("Level Over");
        audioSource.volume = 0.5f;
        audioSource.Play();
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    void DestroyAllTaggedObjects()
    {
        GameObject[] destroyOnWinObjects = GameObject.FindGameObjectsWithTag("destroyOnWin");
        foreach (GameObject taggedObject in destroyOnWinObjects)
        {
            Destroy(taggedObject);
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadLevelNext();
    }
}
