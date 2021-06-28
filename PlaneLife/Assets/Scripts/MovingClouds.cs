using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingClouds : MonoBehaviour
{
    // Start is called before the first frame update

    public float leftThreshold = -700.0f;
    public float rightThreshold = 700.0f;

    public float cloudSpeed = 10.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        if (rect.localPosition.x > rightThreshold)
        {
            rect.localPosition = new Vector3(leftThreshold, rect.localPosition.y, rect.localPosition.z);
        }
        rect.localPosition += new Vector3(cloudSpeed * Time.deltaTime, 0, 0);
        //print(rect.localPosition);
    }
}
