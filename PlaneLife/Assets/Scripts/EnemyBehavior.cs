using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehavior : Unit
{
    public enum MOVEMENT_BEHAVIOR
    {
        LINEAR,
        SINE
    }

    public int damage = 1;

    public float fireRate = 1.0f;

    public float planeSpeed = 5.0f;
    public Vector3 planeDirection = new Vector3(0, 0, 0);

    public GameObject projectile;
    public Vector3 projectileDirection = new Vector3(0, -1, 0);

    protected float timer = 0.0f;
    protected float fTimer = 0.0f;

    public MOVEMENT_BEHAVIOR behavior = MOVEMENT_BEHAVIOR.LINEAR;
    public float curveRadius = 2.0f;
    public float curveSpeed = 5.0f;

    public int score = 1; // Amount to give when unit dies
    public enum CURVE_DIRECTION
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public CURVE_DIRECTION curveDirection = CURVE_DIRECTION.UP;

    public GameObject powerUp;
    public float dropChance = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {   
            float drop = Random.Range(1,100); 
            if (drop <= dropChance ) {
                Instantiate(powerUp, transform.position, transform.rotation);
            }
            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>().score += score;
            Destroy(gameObject);
        }
        if (timer < 1 / fireRate) // Timer for shooting
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
            Fire(projectileDirection);
        }

        switch(behavior)
        {
            case MOVEMENT_BEHAVIOR.LINEAR:
                transform.position += planeDirection * planeSpeed * Time.deltaTime;
                break;
            case MOVEMENT_BEHAVIOR.SINE:
                SineMovement();
                break;
        }

        
    }

    protected void SineMovement()
    {
        fTimer += Time.deltaTime * curveSpeed;
        Vector3 sin = new Vector3(0,0,0);
        switch (curveDirection)
        {
            case CURVE_DIRECTION.UP:
                sin = new Vector3(0, Mathf.Sin(fTimer) * curveRadius, 0);
                break;
            case CURVE_DIRECTION.DOWN:
                sin = new Vector3(0, -Mathf.Sin(fTimer) * curveRadius, 0);
                break;
            case CURVE_DIRECTION.LEFT:
                sin = new Vector3(-Mathf.Sin(fTimer) * curveRadius, 0, 0);
                break;
            case CURVE_DIRECTION.RIGHT:
                sin = new Vector3(Mathf.Sin(fTimer) * curveRadius, 0, 0);
                break;
        }
        
        transform.position += (planeDirection + sin) * planeSpeed * Time.deltaTime;
    }

    protected void Fire(Vector3 direction)
    {
        GameObject projectileCopy = Instantiate(projectile);
        projectileCopy.transform.position = transform.Find("FiringPoint").position;
        projectileCopy.transform.SetParent(GameObject.FindGameObjectWithTag("ProjectileHolder").transform);
        Projectile projScript = projectileCopy.GetComponent<Projectile>();
        projScript.damage = damage;
        projScript.direction = direction;
        projectileCopy.SetActive(true);        
    }

    protected void OnCollisionEnter2D(Collision2D other) {
        Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
    }
}
