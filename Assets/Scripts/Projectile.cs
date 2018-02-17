using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    public float speed, damage;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

     void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        GameObject target = collider.gameObject;
        if (target.gameObject.GetComponent<Attacker>())
        {
            
            if (target.GetComponent<Health>())
            {
                target.GetComponent<Health>().DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    
}
