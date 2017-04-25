using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayLives : MonoBehaviour {

    Text txt;
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = "Letters : " + PlayerPrefs.GetInt("Lives");
    }
}
