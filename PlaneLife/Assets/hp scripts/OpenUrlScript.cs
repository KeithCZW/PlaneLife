using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUrlScript : MonoBehaviour
{
    public string URL;

    public void openURL() {
        Application.OpenURL(URL);
    }
}
