using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;

    public Text scoreText;
    public bool destroy = false;
    void Start()
    {
        if (!destroy)
            DontDestroyOnLoad(transform.gameObject);

        if (GameObject.FindGameObjectsWithTag("Score").Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
            scoreText.text = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>().score.ToString();
    }


}
