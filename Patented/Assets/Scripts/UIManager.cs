using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public void LoadLevel(string level)
	{
		SceneManager.LoadScene (level);
	}
}
