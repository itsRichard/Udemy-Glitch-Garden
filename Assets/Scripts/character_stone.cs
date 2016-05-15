using UnityEngine;
using System.Collections;

public class character_stone : MonoBehaviour {

    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

       
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        Attacker attacker = collider.gameObject.GetComponent<Attacker>();
        // using the presence of an Attacker component to determine if col object is an attacker
        if (attacker)
        {
            animator.SetTrigger("underAttack trigger");
        }
    }

}
