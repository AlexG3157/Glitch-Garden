using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]

public class Attacker : MonoBehaviour {

    public float seenEverySeconds;

    [Range(-1f,1f)]
    float currentSpeed;
    GameObject currentTarget;
    Animator anim;

    // Use this for initialization
    void Start() {

        if (!GetComponent<Rigidbody2D>())
        {
            Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
            myRigidbody.isKinematic = true;
        }
        anim = GetComponent<Animator>();
    

    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        if (!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }

	}

    void OnTriggerEnter2D(Collider2D collision)
    {

        
        
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
        
}
