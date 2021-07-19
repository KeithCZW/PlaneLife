using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void changeScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene, LoadSceneMode.Single);
    }

    public void ResetScore()
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>().score = 0;
    }

    public void UpdateScore()
    {
        int storedScore = 0;
        if (PlayerPrefs.GetInt("prevLvl") == 1)
        {
            storedScore = PlayerPrefs.GetInt("lvl1");
        }
        else
        {
            storedScore = PlayerPrefs.GetInt("lvl2");
        }
            
        int currentScore = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>().score;
        if (currentScore > storedScore)
        {
            if (PlayerPrefs.GetInt("prevLvl") == 1)
                PlayerPrefs.SetInt("lvl1", currentScore);
            else
                PlayerPrefs.SetInt("lvl2", currentScore);
        }
        
    }
}
