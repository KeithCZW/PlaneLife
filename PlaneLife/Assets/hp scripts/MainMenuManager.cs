using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public List<GameObject> skinList;
    private int currentIndex;
    private void Awake() {
        currentIndex = PlayerPrefs.GetInt("SelectedSkin",0);
        foreach(GameObject skin in skinList) {
            skin.SetActive(false);
        }
        skinList[currentIndex].SetActive(true);
    }

    public void nextSkin() {
        skinList[currentIndex].SetActive(false);    
        currentIndex++;
        if(currentIndex >= skinList.Count) {
            currentIndex = 0;
        }
        skinList[currentIndex].SetActive(true);
    }

    public void previousSkin() {
        skinList[currentIndex].SetActive(false);
        currentIndex--;
        if(currentIndex < 0) {
            currentIndex = skinList.Count - 1;
        }
        skinList[currentIndex].SetActive(true);
    }

     public void startGame(int level)
    {
        Debug.Log(currentIndex);
        PlayerPrefs.SetInt("SelectedSkin", currentIndex);
        if (level == 1)
        {
            SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
            PlayerPrefs.SetInt("prevLvl",1);
        }           
        else if (level == 2)
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
            PlayerPrefs.SetInt("prevLvl", 2);
        }
            
    }

    public void ResetScore()
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>().score = 0;
    }
}
