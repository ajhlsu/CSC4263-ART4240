using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCatch : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D collide)
	{
		Application.LoadLevel ("GameOver");
	}

}
