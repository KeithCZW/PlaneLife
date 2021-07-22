using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameScript : MonoBehaviour
{
    public void exitGame() 
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
