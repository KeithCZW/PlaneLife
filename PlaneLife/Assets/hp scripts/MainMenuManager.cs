using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;   
    public GameObject playerSkin;

    public void nextSkin() {
        if (selectedSkin < skins.Count - 1) {
            selectedSkin++;
        } else {
            selectedSkin = 0;
        }
        spriteRenderer.sprite = skins[selectedSkin];
    }

    public void previousSkin() {
        if (selectedSkin > 0) {
            selectedSkin--;
        } else {
            selectedSkin = skins.Count-1;
        }
        spriteRenderer.sprite = skins[selectedSkin];
    }

    public void startGame()
    {
        PrefabUtility.SaveAsPrefabAsset(playerSkin, "Assets/Prefabs/currentSkin.prefab");
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
    }

    public void ResetScore()
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>().score = 0;
    }
}
