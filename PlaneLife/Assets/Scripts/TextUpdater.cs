using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    public TextMesh text;
    public Unit unit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Health:" + unit.health;
    }
}
