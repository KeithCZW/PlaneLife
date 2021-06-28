using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyChanger : MonoBehaviour
{
    public float maxTransparency = 0.4f;
    public float minTransparency = 0.6f;
    public float transparencyChange = 1.0f;
    bool reduceTrans = false;
    CanvasGroup uiElement;

    public float delayBeforeClose = 3.0f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        uiElement = this.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!reduceTrans)
        {
            uiElement.alpha += transparencyChange * Time.deltaTime;
            if (uiElement.alpha >= minTransparency)
            {
                reduceTrans = !reduceTrans;
            }
        }
        else
        {
            uiElement.alpha -= transparencyChange * Time.deltaTime;
            if (uiElement.alpha <= maxTransparency)
            {
                reduceTrans = !reduceTrans;
            }
        }

        timer += Time.deltaTime;
        if (timer >= delayBeforeClose)
        {
            gameObject.SetActive(false);
        }
    }
}
