using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {

    StarDisplay star;

    void Start()
    {
        star = GameObject.FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int amount)
    {
        star.AddStars(amount);
    }

}
