using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXBulletScript : MonoBehaviour
{
    public static AudioClip powerupSound;
    static AudioSource audioSource;

    void Start()
    {
        powerupSound = Resources.Load<AudioClip>("bullet");
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound() {
        audioSource.PlayOneShot(powerupSound);
    }
}
