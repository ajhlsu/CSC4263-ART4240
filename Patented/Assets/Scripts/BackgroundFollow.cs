using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    GameObject go;
    Rigidbody2D rigi;

    void Awake()
    {
        GameObject go = GameObject.Find("Character");
        rigi = go.GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {
        GetComponent<Transform>().position = rigi.transform.position;
    }

}
