using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 10;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
    }

    void Update() 
    {
        if(transform.position.y > 5f)
        {
            Destroy(gameObject);  
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //Debug.Log("TRIGGERED");
        if (other.tag != "Player" 
            && other.tag != "Bullet"
            && other.tag!= "Powerup") {
            Debug.Log(other.name);
            Unit unit = other.transform.GetComponent<Unit>();
            if (unit != null /*&& other.transform.GetComponent<EnemyBehavior>() != null*/)
            {
                SoundManagerScript.PlaySound ("enemyHit");
                unit.health -= 1;
                Destroy(gameObject);
            }
        }
    }
}
