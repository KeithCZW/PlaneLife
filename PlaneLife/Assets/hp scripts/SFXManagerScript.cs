using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManagerScript : MonoBehaviour
{
    public GameObject[] arrayOfSFX;
    public GameObject BGM;

    void Start()
    {
        float SFXmainVol = PlayerPrefs.GetFloat("SFXvolume",1);        
        foreach (GameObject go in arrayOfSFX)
        {
            go.GetComponent<AudioSource>().volume *= SFXmainVol; 
        }

        BGM.GetComponent<AudioSource>().volume *= PlayerPrefs.GetFloat("BGMvolume", 1);
    }
}
