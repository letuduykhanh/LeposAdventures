using UnityEngine;
using System.Collections;

public class Gothrough : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionStay2D (Collision2D other)
	{
		if (other.collider.tag == "Players" || other.collider.tag == "KillPlayer") {
			gameObject.GetComponent<Collider2D> ().enabled = false;
		}
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if (other.collider.tag == "Players" || other.collider.tag == "KillPlayer") {
			gameObject.GetComponent<Collider2D> ().enabled = true;
		}
	}
}
