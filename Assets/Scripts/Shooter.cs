using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile, projectileParent,gun;

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;    //create a new project
        newProjectile.transform.parent = projectileParent.transform;    //create the projectile att he position of parent
        newProjectile.transform.position = gun.transform.position;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
