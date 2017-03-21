using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelTrigger : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D collide)
	{
		Application.LoadLevel ("Completed");
	}

}
