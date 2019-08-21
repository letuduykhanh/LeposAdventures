using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
	public bool fly;
	public float speed;
	private Rigidbody2D rb2d;
	private Animator anim;
	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (fly && transform.localScale.x > 0) {
			rb2d.AddForce (new Vector2 (-speed * 5.0f, 0));
		} else if (fly && transform.localScale.x < 0) {
			rb2d.AddForce (new Vector2 (speed * 5.0f, 0));

		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Fire") {
			fly = true;
			anim.SetBool ("Fly", fly);
		}
	}
}
