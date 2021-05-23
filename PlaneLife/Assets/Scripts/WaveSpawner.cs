using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> waves;
    public List<float> delay;

    private float timer = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (delay.Count > 0 && waves.Count > 0)
        {
            if (timer >= delay[0])
            {
                delay.RemoveAt(0);
                waves[0].SetActive(true);
                waves.RemoveAt(0);
                timer = 0.0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }

    }
}
