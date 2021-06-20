using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Transform leftWall;
    public Transform rightWall;
    public Transform upWall;
    public Transform downWall;

    public float prevPowerupType = 1f;
    public float currPowerupType = 1f;
    public Text power;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        power = GetComponent<Text>();
    }

    public void Update() 
    {
        // Move using mouse 
        //transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

        // Ensure player remains in boundary
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftWall.position.x, rightWall.position.x), Mathf.Clamp(transform.position.y, downWall.position.y, upWall.position.y), transform.position.z);

        // Move using WASD
        // Move horizontal
        float hor = Input.GetAxis("Horizontal");
        transform.position += new Vector3(hor, 0, 0) * playerSpeed;

        //Move vertical
         float ver = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, ver, 0) * playerSpeed;

        // Shoot
        if (/*(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) &&*/ (nextShotTime >= bulletInterval)) {
            Debug.Log("shoot");
            Shoot();
            nextShotTime = 0.0f;
        }
        nextShotTime += Time.deltaTime;
        
        power.text = currPowerupType.ToString();
          
    }

    public void Shoot()
    {
        if (currPowerupType == 1f) { // No power up
            Instantiate(bullet, playerFirePoint.position, playerFirePoint.rotation);
        } else if (currPowerupType == 2f) { // 2 streams but shoot straight
            Instantiate(bullet, playerFirePoint.position + new Vector3(0.5f,0,0), playerFirePoint.rotation);    
            Instantiate(bullet, playerFirePoint.position + new Vector3(-0.5f,0,0), playerFirePoint.rotation);
        } else if (currPowerupType == 3f) { // Spread shot
            Instantiate(bullet, playerFirePoint.position, Quaternion.Euler(0,0,-45));
            Instantiate(bullet, playerFirePoint.position, playerFirePoint.rotation);    
            Instantiate(bullet, playerFirePoint.position, Quaternion.Euler(0,0,45));
        } else if (currPowerupType == 4f) { // Shoot 2 stream but spread
            Instantiate(bullet, playerFirePoint.position + new Vector3(-1f,0,0), Quaternion.Euler(0,0,5));
            Instantiate(bullet, playerFirePoint.position + new Vector3(-1f,0,0), Quaternion.Euler(0,0,-5));   
            Instantiate(bullet, playerFirePoint.position + new Vector3(1f,0,0), Quaternion.Euler(0,0,5));    
            Instantiate(bullet, playerFirePoint.position + new Vector3(1f,0,0), Quaternion.Euler(0,0,-5));
        } else {
            bulletInterval = 0.1f; // Double bullet speed
            currPowerupType = prevPowerupType;
            Shoot();
        }
    }

    private void OnMouseDown() {
        Debug.Log("onMouseDown");
    }
}
