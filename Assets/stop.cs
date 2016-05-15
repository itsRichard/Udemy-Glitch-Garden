using UnityEngine;
using System.Collections;

public class stop : MonoBehaviour {

    private LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnMouseDown()
    {
        levelManager.LoadLevel("01a Start");
    }
}
