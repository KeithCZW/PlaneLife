using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
  public AudioClip pauseSFX;
  public AudioClip resumeSFX;
  public AudioSource audioSource;
  private bool isPaused = false;
  public GameObject pauseMenu;
  // public GameObject[] arrayOfSFXs;
  // private float[] SFXvolInit;
  // public GameObject BGM;
  // private float BGMvolInit;
  // public Slider SFXslider;
  // public Slider BGMSlider;
  //  
  void Start() {
    // pauseSFX = Resources.Load<AudioClip>("pause");
    // resumeSFX = Resources.Load<AudioClip>("resume");
  //   for(int i = 1; i < arrayOfSFXs.Length; i++) {
  //     SFXvolInit[i] = arrayOfSFXs[i].GetComponent<AudioSource>().volume;
  //   }
  //   BGMvolInit = BGM.GetComponent<AudioSource>().volume;
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (isPaused)
      {
        resumeGame();
      }
      else
      {
        pauseGame();
      }
    }
  }
  public void resumeGame()
  {
    audioSource.PlayOneShot(resumeSFX);
    pauseMenu.SetActive(false);
    isPaused = false;
    Time.timeScale = 1f;
  }
  public void pauseGame()
  {
    audioSource.PlayOneShot(pauseSFX);
    pauseMenu.SetActive(true);
    isPaused = true;
    Time.timeScale = 0f;
  }
  
  // public void setSFXVolume()
  // {
  //   for(int i = 1; i < arrayOfSFXs.Length; i++) {
  //     arrayOfSFXs[i].GetComponent<AudioSource>().volume = SFXvolInit[i]*SFXslider.value;
  //   }
  // }

  // public void setBGMVolume() {
  //   BGM.GetComponent<AudioSource>().volume = BGMvolInit*BGMSlider.value;
  // }
}