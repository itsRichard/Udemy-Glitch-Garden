using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

	private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;

	// Use this for initialization
	void Start () {

        // add a rigidbody to this instance
        //Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();   
        //myRigidBody.isKinematic = true;

        gameObject.AddComponent<Rigidbody2D>();
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget)		
        {
            animator.SetBool("isAttacking", false);
        }
		// Events defined in the animation set the movement speed through SetSpeed()
	}

    void OnTriggerEnter2D()
    {
        Debug.Log(name + "Trigger enter");

    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // called from the animator at the time of actual blow 
    public void StrikeCurrentTarget (float damage)
    {
        Debug.Log(name + " striking Target for " + damage);
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }

    }

    public void Attack (GameObject obj)
    {
        currentTarget = obj;
        
    }

}