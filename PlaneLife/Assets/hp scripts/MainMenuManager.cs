using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
  public FlexibleColorPicker flexibleColorPicker;
  public Material mat;
  private float r;
  private float g;
  private float b;

  public GameObject mainMenuBGM;
  public GameObject[] mainMenuSFXarray;
  public GameObject BGMslider;
  private float BGMvolume;
  public GameObject SFXslider;
  private float SFXvolume;

  private void Awake()
  {
    flexibleColorPicker.startingColor = new Color(PlayerPrefs.GetFloat("r", 255), PlayerPrefs.GetFloat("g", 255), PlayerPrefs.GetFloat("b", 255));
    mat.color = new Color(PlayerPrefs.GetFloat("r", 255), PlayerPrefs.GetFloat("g", 255), PlayerPrefs.GetFloat("b", 255));
    BGMvolume = PlayerPrefs.GetFloat("BGMvolume", 0.75F);
    BGMslider.GetComponent<Slider>().value = BGMvolume;
    SFXvolume = PlayerPrefs.GetFloat("SFXvolume", 0.75F);
    SFXslider.GetComponent<Slider>().value = SFXvolume;
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

    BGMvolume = BGMslider.GetComponent<Slider>().value;
    SFXvolume = SFXslider.GetComponent<Slider>().value;
    foreach (GameObject go in mainMenuSFXarray)
    {
      go.GetComponent<AudioSource>().volume = SFXvolume;
    }
    mainMenuBGM.GetComponent<AudioSource>().volume = 0.05F * BGMvolume;
  }

  public void startGame(int level)
  {
    PlayerPrefs.SetFloat("r", r);
    PlayerPrefs.SetFloat("g", g);
    PlayerPrefs.SetFloat("b", b);

    PlayerPrefs.SetFloat("BGMvolume", BGMvolume);
    PlayerPrefs.SetFloat("SFXvolume", SFXvolume);
    Debug.Log(BGMvolume);
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
