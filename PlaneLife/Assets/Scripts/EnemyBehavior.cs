using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehavior : Unit
{
    public enum MOVEMENT_BEHAVIOR
    {
        LINEAR,
        SINE,
        SUICIDE
    }

    public int damage = 1;

    public float fireRate = 1.0f;

    public float planeSpeed = 5.0f;
    public Vector3 planeDirection = new Vector3(0, 0, 0);

    public GameObject projectile;
    public Vector3 projectileDirection = new Vector3(0, -1, 0);
    public float projectileSpeed = 20.0f;
    public bool projectileTracking = false; // Projectile tracks player

    protected float timer = 0.0f;
    protected float fTimer = 0.0f; // used for sine movement

    public MOVEMENT_BEHAVIOR behavior = MOVEMENT_BEHAVIOR.LINEAR;
    public float curveRadius = 2.0f;
    public float curveSpeed = 5.0f;

    public int numberOfBullets = 1;

    public bool despawnUnitTimer = true; // If true, unit despawns after 15s

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

    public GameObject explosion;

    protected float dmgTimer = 0.0f;
    protected bool isBlinking = false;
    protected float blinkTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (despawnUnitTimer)
            Destroy(gameObject, 15.0f);
        if (behavior == MOVEMENT_BEHAVIOR.SUICIDE)
        {
            planeDirection = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
            projectileDirection = planeDirection;
            Vector3 temp = Vector3.Cross(new Vector3(0, -1, 0), planeDirection);
            if (temp.z > 0)
                transform.Rotate(0,0,Vector2.Angle(new Vector2(planeDirection.x,planeDirection.y),new Vector2(0,-1)));
            else
                transform.Rotate(0, 0, -Vector2.Angle(new Vector2(planeDirection.x, planeDirection.y), new Vector2(0, -1)));
            //Debug.Log(Vector2.Angle(new Vector2(planeDirection.x, planeDirection.y), new Vector2(0, -1)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {   
            SFXEnemyDeathScript.PlaySound();
            float drop = Random.Range(1,100); 
            if (drop <= dropChance ) {
                Instantiate(powerUp, transform.position, new Quaternion(0,0,0,0),GameObject.FindGameObjectWithTag("ProjectileHolder").transform);
            }
            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>().score += score;
            Instantiate(explosion, transform.position, new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }
        if (timer < 1 / fireRate) // Timer for shooting
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
            Fire(projectileDirection, numberOfBullets);
        }

        switch(behavior)
        {
            case MOVEMENT_BEHAVIOR.LINEAR:
                transform.position += planeDirection * planeSpeed * Time.deltaTime;
                break;
            case MOVEMENT_BEHAVIOR.SINE:
                SineMovement();
                break;
            case MOVEMENT_BEHAVIOR.SUICIDE:
                transform.position += planeDirection * planeSpeed * Time.deltaTime;
                break;
        }

        if (isBlinking)
        {
            blinkTimer += Time.deltaTime;
            if (blinkTimer > 0.05) // Time to blink transparency
            {
                blinkTimer = 0.0f;
                Color temp = transform.GetComponent<SpriteRenderer>().color;
                if (temp.Equals(new Color(1,1,1)))
                    temp = new Color(1,0.5f,0.5f);
                else
                    temp = new Color(1, 1, 1);
                transform.GetComponent<SpriteRenderer>().color = temp;
            }
            dmgTimer -= Time.deltaTime;
            if (dmgTimer <= 0.0f)
            {
                isBlinking = false;
                Color temp = transform.GetComponent<SpriteRenderer>().color;
                temp = new Color(1, 1, 1);
                transform.GetComponent<SpriteRenderer>().color = temp;
            }
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

    //protected void Fire(Vector3 direction)
    //{
    //    GameObject projectileCopy = Instantiate(projectile);
    //    projectileCopy.transform.position = transform.Find("FiringPoint").position;
    //    projectileCopy.transform.SetParent(GameObject.FindGameObjectWithTag("ProjectileHolder").transform);
    //    Projectile projScript = projectileCopy.GetComponent<Projectile>();
    //    projScript.speed = projectileSpeed;
    //    projScript.damage = damage;
    //    projScript.direction = direction;
    //    projectileCopy.transform.Rotate(transform.rotation.eulerAngles);
    //    projectileCopy.SetActive(true);        
    //}

    protected void Fire(Vector3 direction,int numberOfBullets = 1)
    {
        float angleDifference = 90.0f / numberOfBullets;
        for (int i = 0; i < numberOfBullets; i++)
        {
            GameObject projectileCopy = Instantiate(projectile, GameObject.FindGameObjectWithTag("ProjectileHolder").transform);
            projectileCopy.transform.position = transform.Find("FiringPoint").position;
            Projectile projScript = projectileCopy.GetComponent<Projectile>();
            projScript.speed = projectileSpeed;
            projScript.damage = damage;
            if (!projectileTracking)
                projScript.direction = direction;
            else
                projScript.direction = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
            projectileCopy.transform.Rotate(transform.rotation.eulerAngles);
            if (projectileTracking)
            {
                Vector3 tempDirection = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
                Vector3 temp = Vector3.Cross(new Vector3(0, -1, 0), tempDirection);
                if (temp.z > 0)
                    projectileCopy.transform.Rotate(0, 0, Vector2.Angle(new Vector2(tempDirection.x, tempDirection.y), new Vector2(0, -1)));
                else
                    projectileCopy.transform.Rotate(0, 0, -Vector2.Angle(new Vector2(tempDirection.x, tempDirection.y), new Vector2(0, -1)));
            }
            projectileCopy.transform.Rotate(0, 0, -angleDifference * (numberOfBullets - 1) / 2 + angleDifference * i);
            projScript.direction = Quaternion.Euler(0, 0, -angleDifference * (numberOfBullets - 1) / 2 + angleDifference * i) * projScript.direction;
            projectileCopy.SetActive(true);
        }
    }

    public override void TakeDamage(int dmg)
    {
        health -= dmg;
        isBlinking = true;
        dmgTimer = 0.3f;
    }

    protected virtual void OnCollisionEnter2D(Collision2D other) {
        Unit unit = other.transform.GetComponent<Unit>();

        if (unit != null && other.transform.GetComponent<EnemyBehavior>() == null && other.transform.GetComponent<BossBehavior>() == null)
        {
            if (!other.transform.GetComponent<PlayerScript>().immortal)
            {
                other.transform.GetComponent<PlayerScript>().TurnImmortal();
                unit.health -= damage;
                Instantiate(explosion, transform.position, new Quaternion(0, 0, 0, 0));
                Destroy(gameObject);
            }
        }
    }
}
