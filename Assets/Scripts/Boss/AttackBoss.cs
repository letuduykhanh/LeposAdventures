using UnityEngine;
using System.Collections;

public class AttackBoss : MonoBehaviour {
	private Animator MyAnimator;

	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Boss")
		{
			Destroy (gameObject);
		}
	}

}
