using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;  
    // each button is going to be assigned a defender pre fab that everyone can see

    private Button[] buttonArray;
    private Text costText;

    public static GameObject selectedDefender;     

    //By making selectedDefender PUBLIC and STATIC, the game will know at any time what the selected
    //defender is, and that there can only be one selcted at any given time.  

	// Use this for initialization
	void Start () {
        // Find all GameObjects that are buttons when this thing is initialized; on start
        // then, put them in an array.  
        buttonArray = GameObject.FindObjectsOfType<Button>();

        // Find text component (the cost), set it to the buttons's prefab's starcost

        if (!GetComponentInChildren<Text>()) { Debug.LogWarning(name + " has no cost "); }
        GetComponentInChildren<Text>().text = GetComponent<Button>().defenderPrefab.GetComponent<Defenders>().starCost.ToString();



        //Alt 1
        //  defenderPrefab.GetComponent<Defenders>().starCost

        //alt 2
        //costText = GetComponentInChildren<Text>();
        //costText.text = GetComponent<Button>().defenderPrefab.GetComponent<Defenders>().starCost.ToString();

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
