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
    public bool showHighscore = false;
    public int highScoreLvl = 1;
    public bool setPreviousLevel = false;
    public bool win = false;
    void Start()
    {
        if (!destroy)
            DontDestroyOnLoad(transform.gameObject);

        if (GameObject.FindGameObjectsWithTag("Score").Length > 1 && !destroy)
        {
            Destroy(this.gameObject);
        }

        if (setPreviousLevel)
            highScoreLvl = PlayerPrefs.GetInt("prevLvl");
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
            scoreText.text = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>().score.ToString();

        if (showHighscore)
        {
            if (highScoreLvl == 1)
                scoreText.text = PlayerPrefs.GetInt("lvl1").ToString();
            else if (highScoreLvl == 2)
                scoreText.text = PlayerPrefs.GetInt("lvl2").ToString();
        }
    }


}
