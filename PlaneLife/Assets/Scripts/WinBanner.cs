using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinBanner : MonoBehaviour
{
    // Start is called before the first frame update
    public bool appearIfWin = true;
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Score") != null)
        {
            if (GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>().win == appearIfWin)
            {
                GetComponent<Text>().enabled = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
