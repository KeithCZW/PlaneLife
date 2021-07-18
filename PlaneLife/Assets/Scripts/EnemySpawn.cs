using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    float transparencyChangeSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Color currentColor = transform.GetComponent<SpriteRenderer>().color;
        transform.GetComponent<SpriteRenderer>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Color currentColor = transform.GetComponent<SpriteRenderer>().color;
        transform.GetComponent<SpriteRenderer>().color = new Color(currentColor.r,currentColor.g,currentColor.b,currentColor.a + transparencyChangeSpeed * Time.deltaTime);
        if (transform.GetComponent<SpriteRenderer>().color.a >= 1)
        {
            transform.GetComponent<EnemyBehavior>().enabled = true;
            transform.GetComponent<PolygonCollider2D>().enabled = true;
            this.enabled = false;
        }
    }
}
