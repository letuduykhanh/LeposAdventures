using UnityEngine;
using System.Collections;

public class DropDown : MonoBehaviour
{
	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	IEnumerator drop ()
	{
		yield return new WaitForSeconds (0.1f);
		rb2d.isKinematic = false;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Players") {
			StartCoroutine ("drop");
		}
	}
}
