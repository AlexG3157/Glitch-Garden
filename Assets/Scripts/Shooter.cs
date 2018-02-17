using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    public float projectileSpeed;

    GameObject projectileParent;
    Animator animator;
    Spawner mySpawner;

    void Start()
    {
        animator = GetComponent<Animator>();

        projectileParent = GameObject.Find("Projectiles");

        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
        
    }

    private void Update()
    {

        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

    }


    void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
         
    }

    bool IsAttackerAheadInLane()
    {

        if(mySpawner.transform.childCount > 0)
        {
            foreach(Transform attacker in mySpawner.transform)
            {
              if(attacker.transform.position.x > transform.position.x)
                {
                    return true;
                }
            }
            
        }

        return false;
    }

    void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach (Spawner spawner in spawnerArray)
        {
            if(spawner.transform.position.y == transform.position.y)
            {
                mySpawner = spawner;
                return;
            }

            
        }
        Debug.LogError("Cant Find Spawner in Lane");
    }

}
