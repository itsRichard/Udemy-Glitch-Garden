using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	private GameObject parent;
    private StarDisplay starDisplay;

	private void Start()
	{
		parent = GameObject.Find ("Defenders");	// search the scene for a game object called Projectiles 
		if (!parent) {
			parent = new GameObject ("Defenders");	// Create a new game object called Projectiles
		}
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}

	void OnMouseDown(){
		//print (Input.mousePosition);
		//print (SnapToGrid(CalculateWorldPointOfMouseClick()));
		if (!Button.selectedDefender) {
			Debug.Log ("Defender is Null");
		}

        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        //GameObject defender = Button.selectedDefender;

        int defenderCost = Button.selectedDefender.GetComponent<Defenders>().starCost;

        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, Button.selectedDefender);
        }
         else
        {
            Debug.Log("Insufficient stars to spawn");
        }


		
	}

    void SpawnDefender (Vector2 roudnedPos, GameObject defender)
    {
        Quaternion zeroRot = Quaternion.identity;
        GameObject newDefender = Instantiate(defender, roudnedPos, zeroRot) as GameObject;
        newDefender.transform.parent = parent.transform;
    }

	Vector2 SnapToGrid (Vector2 rawWorldPos){
		int newX = Mathf.RoundToInt (rawWorldPos.x);
		int newY = Mathf.RoundToInt (rawWorldPos.y);
		return new Vector2(newX, newY);
	}
		

	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera); // required for ScreenToWorldPoint
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);
		return worldPos;

	}
}
