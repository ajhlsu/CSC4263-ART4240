using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayLives : MonoBehaviour {

    Text txt;
    int lives;
    void Start()
    {
        lives = PlayerPrefs.GetInt("Lives");
        txt = gameObject.GetComponent<Text>();
        if(lives>1)
        {
            txt.text = "!! Warning: Only " + lives + " letters left !!";
        }

        else
        {
            txt.text = "!! Warning: Only " + lives + " letter left !!";
        }
        
    }
}
