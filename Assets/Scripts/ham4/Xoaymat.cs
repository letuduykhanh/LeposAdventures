using UnityEngine;
using System.Collections;

public class Xoaymat : MonoBehaviour
{
	public PlayerMovements player;
	// Use this for initialization
	void Start ()
	{
		player = FindObjectOfType<PlayerMovements> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Players") {
			Vector3 theScale = player.transform.localScale;
			theScale.x = -0.2f;
			player.transform.localScale = theScale;
		}
	}
}
