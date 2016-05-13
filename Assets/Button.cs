using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;  
    // each button is going to be assigned a defender pre fab that everyone can see

    private Button[] buttonArray;
    public static GameObject selectedDefender;     

    //By making selectedDefender PUBLIC and STATIC, the game will know at any time what the selected
    //defender is, and that there can only be one selcted at any given time.  

	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        // Find all GameObjects that are buttons when this thing is initialized; on start
        // then, put them in an array.  
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()	// Captures OnMouseDown event on this game object's Collider
    {
        foreach (Button thisButton in buttonArray)  // Loop through the array and make them all black... 
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        
        // ... then, turn the one that is Selcted back on, to white.  
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;

    }
}
