using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    public bool boss = false;

    public Unit player;

    private int maxHealth;
    private float maxHeight;
    private float maxWidth;
    void Start()
    {
        maxHealth = player.health;
        maxHeight = transform.GetComponent<RectTransform>().rect.height;
        maxWidth = transform.GetComponent<RectTransform>().rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        if (boss != true)
        {
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(35, (float)player.health / (float)maxHealth * maxHeight);
        }
        else
        {
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2((float)player.health / (float)maxHealth * maxWidth, 35);
        }
    }
}
