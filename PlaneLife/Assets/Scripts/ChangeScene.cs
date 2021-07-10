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
        int storedScore = PlayerPrefs.GetInt("lvl1");
        int currentScore = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>().score;
        if (currentScore > storedScore)
        {
            PlayerPrefs.SetInt("lvl1", currentScore);
        }
        
    }
}
