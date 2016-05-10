﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
public class character_cammy : MonoBehaviour 
{

    private Animator anim;
    private Attacker attacker;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(name + " collided with " + col);
        GameObject obj = col.gameObject;

        if (!obj.GetComponent<Defenders>())
        {
            return;
        }

        else
        {
            anim.SetBool("isAttacking", true);
            attacker.Attack(obj); // Set the current target to the thing this collided with 
        }


    }
}
