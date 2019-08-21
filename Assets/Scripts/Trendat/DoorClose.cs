using UnityEngine;
using System.Collections;

public class DoorClose : MonoBehaviour {
	private Animator MyAnimator;
	public Action_door acd;
	// Use this for initialization
	void Start()
	{
		MyAnimator = GetComponent<Animator>();
		acd = FindObjectOfType<Action_door>();

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Players")
		{
			acd.doorclose ();
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
