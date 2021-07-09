using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
  private float speed;
  public Transform upWall;
  public Transform downWall;

  void Start()
  {
      speed = Random.Range(0.5f, 1.0f);
      float darkness = speed * 100f - 0.25f;
      //Debug.Log("speed " + speed);
      //Debug.Log("dakness " + darkness);
      GetComponent<SpriteRenderer>().color = new Color(darkness,darkness,darkness);
    //   GetComponent<SpriteRenderer>().color = new Color(0.2f,0.2f,0.2f);
  }

  void Update()
  {
    if (transform.position.y < downWall.position.y - 2f)
    {
      transform.position = new Vector3(transform.position.x, upWall.position.y + 2f, transform.position.z);
    }
    else
    {
      transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
    }
  }
}
