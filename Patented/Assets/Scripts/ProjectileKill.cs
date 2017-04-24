using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileKill : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy (collision.gameObject.transform.parent.gameObject);
		Destroy (gameObject);
	}
}
