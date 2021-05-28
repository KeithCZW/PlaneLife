using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float playerSpeed = 0.5f;
    
    public float screenWidth = 10.4f;
    public float screenHeight = 4.5f;

    public Transform playerFirePoint;
    public GameObject bullet;
    public float bulletInterval = 0.2f;
    private float nextShotTime = 0f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        // Move using mouse 
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

        // Ensure player remains in boundary
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -screenWidth, screenWidth), Mathf.Clamp(transform.position.y, -screenHeight, screenHeight), transform.position.z);
 
        // Move using WASD
        // Move horizontal
        // float hor = Input.GetAxis("Horizontal");
        // transform.position += new Vector3(hor, 0, 0) * playerSpeed;

        // Move vertical
        // float ver = Input.GetAxis("Vertical");
        // transform.position += new Vector3(0, ver, 0) * playerSpeed;

        // wrong 
        // rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*playerSpeed, Input.GetAxis("Vertical")*playerSpeed));
        // rb.AddForce(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)));

        // Shoot
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && (nextShotTime <= Time.time)) {
            Debug.Log("shoot");
            Shoot();
            nextShotTime = Time.time + bulletInterval;
        }

        // // Reset to start
        // if (Input.GetKeyDown(KeyCode.R)) {
        //     transform.position = new Vector3(0,-4,0);
        // }
          
    }

    void Shoot()
    {
        Instantiate(bullet, playerFirePoint.position, playerFirePoint.rotation);
    }

    private void OnMouseDown() {
        Debug.Log("onMouseDown");
    }
}
