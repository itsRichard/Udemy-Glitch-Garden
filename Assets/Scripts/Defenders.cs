using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {

    StarDisplay star;
    public int starCost = 100;

    void Start()
    {
        star = GameObject.FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int amount)
    {
        star.AddStars(amount);
    }

}
