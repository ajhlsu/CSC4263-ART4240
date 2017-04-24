using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGunScript : MonoBehaviour 
{
	GameObject go;
	Rigidbody2D rigi;
	bool hasItem = false;
	Vector3 character;
	Vector3 hover;


	private void OnTriggerEnter2D(Collider2D other)
	{
		hasItem = true;
		rigi = other.GetComponent<Rigidbody2D> ();
		other.GetComponent<CharacterControllerScript> ().hasItem = 2;
	}

	private void Update()
	{
		if (hasItem) 
		{
			character = rigi.position;
			character.Set (character.x, character.y + 2, character.z);
			GetComponent<Transform> ().position = character;

		}
	}
}
