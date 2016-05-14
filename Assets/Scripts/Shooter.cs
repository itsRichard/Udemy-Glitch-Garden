using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    // What's being shot, who is it being shot by, and what's it being shot out of.
    // All different elements of the defender e.g. A cactus shoots courgettes out of its own gun 
    public GameObject projectile,gun;
	private GameObject projectileParent;
    private Spawner myLaneSpawner;

    private Animator animator;

	private void Start()
	{
        animator = GameObject.FindObjectOfType<Animator> ();
        // why not get compontent?

		projectileParent = GameObject.Find ("Projectiles");	// search the scene for a game object called Projectiles 
		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles");	// Create a new game object called Projectiles
		}
        SetMyLaneSpawner();

    }

    void SetMyLaneSpawner()
    {
        // find the spawner associated with this shooter.
        
        // using the FindObjectsOfType function of GameObject, find all Spawner in the scene
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        
        // check each spawner for a match
        foreach (Spawner AttackingSpawner in spawnerArray)
        {
            if (AttackingSpawner.transform.position.y == gameObject.transform.position.y)
            {
                myLaneSpawner = AttackingSpawner;
                Debug.Log("Attacking Spawner found for Shooter in Lane " + gameObject.transform.position.y);
            }
        }
        if (!myLaneSpawner) { Debug.LogError("No attacking spawner found for Shooter in lane " + gameObject.transform.position.y); }
    }

    // Fire is trigged by the defender animation event
    private void Fire()
    {

        GameObject newProjectile = Instantiate(projectile) as GameObject;    //create a new object (projectile)

        newProjectile.transform.parent = projectileParent.transform;    //assign the object as a child of its parent (the shooter)

		newProjectile.transform.position = gun.transform.position;  // place the projectile at the position of the gun 
        // further movement of the projectile is dicated by projectile.cs.  
    }

   void Update()
    {
        // if there is an attacker in the lane, shoot at it, else don't be attacking stuff
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    bool IsAttackerAheadInLane()
    {
        if (myLaneSpawner.transform.childCount <=0)
        {
            return false;
        }

        // check each attacker being spawn
        foreach (Transform attacker in myLaneSpawner.transform)
        {
            // is the attacker ahead of the defender/shooter
            if (attacker.transform.position.x > transform.position.x) 
            {
                return true;
            }
        }
        //attacker is in the lane but behind use
        return false;  
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
