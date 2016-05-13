using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;
	// These are set by the prefab gameobject which this script is attached to.  

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
		// As soon as this thing is created, move it right.  
	}


    void OnTriggerEnter2D(Collider2D col)
    {
        Attacker attacker = col.gameObject.GetComponent<Attacker>();
        Health health = col.gameObject.GetComponent<Health>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }


    }
}
