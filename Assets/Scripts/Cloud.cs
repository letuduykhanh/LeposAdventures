using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour
{
	public float speed;

	// Update is called once per frame
	void Update ()
	{
		transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
	}

	void OnBecameInvisible ()
	{
		//Destroy (gameObject);
	}
		
}
