using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    // What's being shot, who is it being shot by, and what's it being shot out of.
    // All different elements of the defender e.g. A cactus shoots courgettes out of its own gun 
    public GameObject projectile,gun;
	private GameObject projectileParent;

	private void Start()
	{
		projectileParent = GameObject.Find ("Projectiles");	// search the scene for a game object called Projectiles 
		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles");	// Create a new game object called Projectiles
		}
	}


    // Fire is trigged by the defender animation event
    private void Fire()
    {
		Debug.Log ("Spawning new projectile");
        GameObject newProjectile = Instantiate(projectile) as GameObject;    //create a new object (projectile)
		Debug.Log ("Spawning new projectile 2");
        newProjectile.transform.parent = projectileParent.transform;    //assign the object as a child of its parent (the shooter)
		Debug.Log ("Spawning new projectile 3 ");
		newProjectile.transform.position = gun.transform.position;  // place the projectile at the position of the gun 
        // further movement of the projectile is dicated by projectile.cs.  
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
