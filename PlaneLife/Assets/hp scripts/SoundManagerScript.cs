using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
  public static AudioClip movementSound, bulletSound, bulletBoostedSound, collectPowerupSound, enemyHitSound, enemyDeathSound;
  static AudioSource audioSource;
  // Start is called before the first frame update
  void Start()
  {
    movementSound = Resources.Load<AudioClip>("movement");
    bulletSound = Resources.Load<AudioClip>("bullet");
    bulletBoostedSound = Resources.Load<AudioClip>("bulletBoosted");
    collectPowerupSound = Resources.Load<AudioClip>("collectPowerup");
    enemyHitSound = Resources.Load<AudioClip>("enemyHit");
    enemyDeathSound = Resources.Load<AudioClip>("enemyDeath");
    audioSource = GetComponent<AudioSource>();
  }
  void Update()
  {

  }

  public static void PlaySound(string clip)
  {
    switch (clip)
    {
      case "movement":
        audioSource.PlayOneShot(movementSound);
        break;
      case "bullet":
        audioSource.volume = 0.02f;
        audioSource.PlayOneShot(bulletSound);
        break;
      case "bulletBoosted":
        audioSource.volume = 0.3f;
        audioSource.PlayOneShot(bulletBoostedSound);
        break;
      case "collectPowerup":
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(collectPowerupSound);
        break;
      case "enemyHit":
        audioSource.volume = 0.03f;
        audioSource.PlayOneShot(enemyHitSound);
        break;
      case "enemyDeath":
        audioSource.volume = 1f;
        audioSource.PlayOneShot(enemyDeathSound);
        break;
    }
  }
}
