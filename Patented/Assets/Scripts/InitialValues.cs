using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialValues : MonoBehaviour
{
	void Start ()
    {
        PlayerPrefs.SetInt("Lives", 3);

    }
}
