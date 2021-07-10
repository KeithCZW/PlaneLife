using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterScene : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 1, 0) * Time.deltaTime * speed;
        if (transform.localPosition.y >= -6.5)
        {
            transform.GetComponent<PlayerScript>().enabled = true;
            this.enabled = false;
        }
    }
}
