using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
  public Sprite boosted;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
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
    transform.position += new Vector3(hor, 0, 0) * playerSpeed * Time.deltaTime;
    
    //Move vertical
    float ver = Input.GetAxis("Vertical");
    transform.position += new Vector3(0, ver, 0) * playerSpeed * Time.deltaTime;

    // Shoot
    if (/*(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) &&*/ (nextShotTime >= bulletInterval))
    {
      Shoot();
      nextShotTime = 0.0f;
    }
    nextShotTime += Time.deltaTime;

    if (transform.GetComponent<Unit>().health <= 0)
    {
        SceneManager.LoadScene("ScoreScene", LoadSceneMode.Single);
    }

    }

  public void Shoot()
  {
    if (bulletInterval == 0.2f) {
      SoundManagerScript.PlaySound("bullet");
    } else if (bulletInterval == 0.1f) {
      SoundManagerScript.PlaySound ("bulletBoosted");
    } else {}

    if (currPowerupType == 1f)
    {
            GameObject b1 = Instantiate(bullet, playerFirePoint.position, playerFirePoint.rotation);
        setBulletSprite(b1);

    }
    else if (currPowerupType == 2f)
    {
      GameObject b1 = Instantiate(bullet, playerFirePoint.position + new Vector3(0.5f, -0.5f, 0), playerFirePoint.rotation);
      GameObject b2 = Instantiate(bullet, playerFirePoint.position + new Vector3(-0.5f, -0.5f, 0), playerFirePoint.rotation);
      setBulletSprite(b1);
      setBulletSprite(b2);
    }
    else if (currPowerupType == 3f)
    {
      GameObject b1 = Instantiate(bullet, playerFirePoint.position, Quaternion.Euler(0, 0, -45));
      GameObject b2 = Instantiate(bullet, playerFirePoint.position, playerFirePoint.rotation);
      GameObject b3 = Instantiate(bullet, playerFirePoint.position, Quaternion.Euler(0, 0, 45));
      setBulletSprite(b1);
      setBulletSprite(b2);
      setBulletSprite(b3);
    }
    else if (currPowerupType == 4f)
    {
      GameObject b1 = Instantiate(bullet, playerFirePoint.position + new Vector3(-0.9f, -0.8f, 0), Quaternion.Euler(0, 0, 5));
      GameObject b2 = Instantiate(bullet, playerFirePoint.position + new Vector3(-0.9f, -0.8f, 0), Quaternion.Euler(0, 0, -5));
      GameObject b3 = Instantiate(bullet, playerFirePoint.position + new Vector3(0.9f, -0.8f, 0), Quaternion.Euler(0, 0, 5));
      GameObject b4 = Instantiate(bullet, playerFirePoint.position + new Vector3(0.9f, -0.8f, 0), Quaternion.Euler(0, 0, -5));
      setBulletSprite(b1);
      setBulletSprite(b2);
      setBulletSprite(b3);
      setBulletSprite(b4);
    }
    else
    {
      bulletInterval = 0.1f;
      Invoke("setBulletInterval", 3);
      currPowerupType = prevPowerupType;
      Shoot();
    } 
  }

  void setBulletSprite(GameObject bullet)
  {
    if (bulletInterval != 0.2f)
    {
      bullet.GetComponent<SpriteRenderer>().sprite = boosted;
    }
  }

  void setBulletInterval()
  {
    bulletInterval = 0.2f;
  }
}
