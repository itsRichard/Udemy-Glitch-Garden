using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    // What's being shot, who is it being shot by, and what's it being shot out of.
    // All different elements of the defender e.g. A cactus shoots courgettes out of its own gun 
    public GameObject projectile, projectileParent,gun;

    // Fire is trigged by the defender animation event
    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;    //create a new object (projectile)
        newProjectile.transform.parent = projectileParent.transform;    //assign the object as a child of its parent (the shooter)
        newProjectile.transform.position = gun.transform.position;  // place the projectile at the position of the gun 
        // further movement of the projectile is dicated by projectile.cs.  
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
