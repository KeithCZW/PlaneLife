using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehavior : EnemyBehavior
{
    // Start is called before the first frame update
    public List<int> healthThresholds;
    int currentPhase = 0;
    public GameObject leftBoundary;
    public GameObject rightBoundary;
    public GameObject EnemySpawns;

    bool movingLeft = true;

    int bulletSpread = 1;

    float enemySpawnTimer = 3.0f;
    int enemyCount = 0;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>().win = true;
            SceneManager.LoadScene("ScoreScene", LoadSceneMode.Single);
        }
        

        if (healthThresholds.Count > 0)
        {
            if (health <= healthThresholds[0])
            {
                healthThresholds.RemoveAt(0);
                currentPhase++;
            }
        }
        if (currentPhase == 0)
        {
            planeDirection = new Vector3(0, -1, 0);
            if (transform.localPosition.y <= 2.9)
            {
                currentPhase++;
            }
            transform.position += planeDirection * planeSpeed * Time.deltaTime;
        }
        else if (currentPhase == 1)
        {
            if (movingLeft)
            {
                planeDirection = new Vector3(-1, 0, 0);
                if (transform.position.x < leftBoundary.transform.position.x)
                {
                    movingLeft = !movingLeft;
                }
            } 
            else
            {
                planeDirection = new Vector3(1, 0, 0);
                if (transform.position.x > rightBoundary.transform.position.x)
                {
                    movingLeft = !movingLeft;
                }
            }
            transform.position += planeDirection * planeSpeed * Time.deltaTime;
        }
        else if (currentPhase == 2)
        {
            curveDirection = CURVE_DIRECTION.UP;
            fireRate = 1.5f;
            bulletSpread = 3;
            if (movingLeft)
            {
                planeDirection = new Vector3(-1, 0, 0);
                if (transform.position.x < leftBoundary.transform.position.x)
                {
                    movingLeft = !movingLeft;
                }
            }
            else
            {
                planeDirection = new Vector3(1, 0, 0);
                if (transform.position.x > rightBoundary.transform.position.x)
                {
                    movingLeft = !movingLeft;
                }
            }
            SineMovement();
        }
        else if (currentPhase == 3)
        {
            curveDirection = CURVE_DIRECTION.LEFT;
            fireRate = 1.0f;
            bulletSpread = 6;
            projectileSpeed = 5.0f;
            if (movingLeft)
            {
                planeDirection = new Vector3(-1, 0, 0);
                if (transform.position.x < leftBoundary.transform.position.x)
                {
                    movingLeft = !movingLeft;
                }
            }
            else
            {
                planeDirection = new Vector3(1, 0, 0);
                if (transform.position.x > rightBoundary.transform.position.x)
                {
                    movingLeft = !movingLeft;
                }
            }
            SineMovement();
        }

        if (timer < 1 / fireRate) // Timer for shooting
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
            Fire(projectileDirection, bulletSpread);
        }

        if (enemySpawnTimer <= 0.0f)
        {
            Transform enemy = Instantiate(EnemySpawns.transform.GetChild(enemyCount));
            enemy.position = EnemySpawns.transform.GetChild(enemyCount).position;
            enemy.gameObject.SetActive(true);
            enemySpawnTimer = 3.0f;
            enemyCount++;
            if (enemyCount > 2)
            {
                enemyCount = 0;
            }
        }
        enemySpawnTimer -= Time.deltaTime;

        if (isBlinking)
        {
            blinkTimer += Time.deltaTime;
            if (blinkTimer > 0.05) // Time to blink transparency
            {
                blinkTimer = 0.0f;
                Color temp = transform.GetComponent<SpriteRenderer>().color;
                if (temp.Equals(new Color(1, 1, 1)))
                    temp = new Color(1, 0.5f, 0.5f);
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

    public override void TakeDamage(int dmg)
    {
        if (currentPhase > 0)
        {
            health -= dmg;
            isBlinking = true;
            dmgTimer = 0.3f;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        Unit unit = other.transform.GetComponent<Unit>();

        if (unit != null && other.transform.GetComponent<EnemyBehavior>() == null && other.transform.GetComponent<BossBehavior>() == null)
        {
            if (!other.transform.GetComponent<PlayerScript>().immortal)
            {
                other.transform.GetComponent<PlayerScript>().TurnImmortal();
                unit.health -= damage;
            }
        }
    }
}
