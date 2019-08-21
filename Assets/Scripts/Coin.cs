using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
	private Animator anim;
	private Transform target;
	public GameObject CoinUI;
	public bool move;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		target = CoinUI.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		


	}

	void FixedUpdate ()
	{
		
		transform.LookAt (target.position);
		transform.Rotate (new Vector2 (target.position.x, -90), Space.Self);
		if (move) {
			transform.Translate (new Vector2 (15 * Time.deltaTime, 0.1f));
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Players") {
			move = true;
			anim.SetBool ("Change", true);
			GetComponent<AudioSource> ().Play ();

		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Players") {
			anim.SetBool ("Change", false);
		}
	}
}
