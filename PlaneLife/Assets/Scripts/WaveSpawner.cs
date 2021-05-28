using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct Wave {
        public GameObject wave;
        public float delay;
    }
    // Start is called before the first frame update
    public List<Wave> waves;
    //public List<float> delay;

    private float timer = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waves.Count > 0)
        {
            if (timer >= waves[0].delay)
            {
                waves[0].wave.SetActive(true);
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
