using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    public Unit player;

    private int maxHealth;
    private float maxHeight;
    void Start()
    {
        maxHealth = player.health;
        maxHeight = transform.GetComponent<RectTransform>().rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(35, (float)player.health / (float)maxHealth * maxHeight);
    }
}
