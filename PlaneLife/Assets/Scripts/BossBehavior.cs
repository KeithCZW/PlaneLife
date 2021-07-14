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

    bool movingLeft = true;

    int bulletSpread = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
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

    }

}
