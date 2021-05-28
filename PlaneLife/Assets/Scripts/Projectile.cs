using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1;
    public float speed = 25.0f;
    public Vector3 direction;

    private float despawnTime = 5.0f;

    public bool isPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, despawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("TEST");
        Unit unit = collision.transform.GetComponent<Unit>();
        if (isPlayer)
        {
            if (unit != null && collision.transform.GetComponent<EnemyBehavior>() != null)
            {
                unit.health -= damage;
                Destroy(gameObject);
            }
        }
        else
        {
            if (unit != null && collision.transform.GetComponent<EnemyBehavior>() == null)
            {
                unit.health -= damage;
                Destroy(gameObject);
            }
        }
    }
}
