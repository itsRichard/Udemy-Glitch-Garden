using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 100f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DealDamage(float damage)
    {
        if ((health-= damage) > 0)
        {
            health = health - damage;
        }
        if (health < 0)
        {
            // Trigger Death State Here
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

}
