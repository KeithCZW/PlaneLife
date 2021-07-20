using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
  public FlexibleColorPicker flexibleColorPicker;
  public Material mat;
  private float r;
  private float g;
  private float b;

  private void Awake()
  {
    flexibleColorPicker.startingColor = new Color(PlayerPrefs.GetFloat("r", 255), PlayerPrefs.GetFloat("g", 255), PlayerPrefs.GetFloat("b", 255));
    mat.color = new Color(PlayerPrefs.GetFloat("r", 255), PlayerPrefs.GetFloat("g", 255), PlayerPrefs.GetFloat("b", 255));
  }

  public void OpenColorCustomizer()
  {
    flexibleColorPicker.gameObject.SetActive(true);
  }

  public void CloseColorCustomizer()
  {
    flexibleColorPicker.gameObject.SetActive(false);
  }

  void Update()
  {
    mat.color = flexibleColorPicker.color;
    r = flexibleColorPicker.color.r;
    g = flexibleColorPicker.color.g;
    b = flexibleColorPicker.color.b;
  }

  public void startGame(int level)
  {
    PlayerPrefs.SetFloat("r", r);
    PlayerPrefs.SetFloat("g", g);
    PlayerPrefs.SetFloat("b", b);
    if (level == 1)
    {
      SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
      PlayerPrefs.SetInt("prevLvl", 1);
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
