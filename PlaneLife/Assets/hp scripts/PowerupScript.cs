using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    public float powerupType;
    public float powerupSpeed;
    private Rigidbody2D rb;

    void Start()
    {   powerupType = Random.Range(2,6); 
        powerupSpeed = powerupType;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * powerupSpeed;
    }

    void Update() 
    {
        if(transform.position.y < -10f)
        {
            Destroy(gameObject);  
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") 
        {
            other.gameObject.GetComponent<PlayerScript>().prevPowerupType = other.gameObject.GetComponent<PlayerScript>().currPowerupType;
            other.gameObject.GetComponent<PlayerScript>().currPowerupType = this.powerupType;
            Destroy(gameObject);
        } else {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        } 
    }
}
