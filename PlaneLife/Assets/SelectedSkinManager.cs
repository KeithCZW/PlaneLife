using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedSkinManager : MonoBehaviour
{
    public GameObject selectedSkin;
    public GameObject player;
    private Sprite playerSprite;

    void Start()
    {
        playerSprite = selectedSkin.GetComponent<SpriteRenderer>().sprite;
        player.GetComponent<SpriteRenderer>().sprite = playerSprite;
    }
}
