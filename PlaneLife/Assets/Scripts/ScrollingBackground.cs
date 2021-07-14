using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    // Start is called before the first frame update

    public float bottomLimit = -8.3f;
    public float pushUp = 10.0f;
    public float moveSpeed = 10.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform rect = gameObject.GetComponent<Transform>();
        if (rect.localPosition.y < bottomLimit)
        {
            rect.localPosition += new Vector3(0, pushUp, 0);
        }
        rect.localPosition -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
        //print(rect.localPosition);
    }
}
