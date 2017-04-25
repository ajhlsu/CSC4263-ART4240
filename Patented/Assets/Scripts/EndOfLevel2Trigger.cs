using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndOfLevel2Trigger : MonoBehaviour 
{
	public class EndOfLevel1Trigger : MonoBehaviour 
	{
		private void OnTriggerEnter2D(Collider2D collide)
		{
			SceneManager.LoadScene("2 Completed");
		}
	}
}
