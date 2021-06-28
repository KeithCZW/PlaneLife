using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
  public Transform upWall;
  public Transform rightWall;
  private Vector3 startX;
  // Start is called before the first frame update
  void Start()
  {
      startX = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.x > rightWall.position.x + 2f)
    {
      transform.position = startX;
    }
    else
    {
      transform.position += new Vector3(0.5f, -0.5f, 0) * Time.deltaTime;
    }
  }
}
