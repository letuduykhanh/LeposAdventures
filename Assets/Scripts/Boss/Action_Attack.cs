using UnityEngine;
using System.Collections;

public class Action_Attack : MonoBehaviour {


	public GameObject ob;

	private AttackBoss ab;
	// Use this for initialization
	void Start () {
		ab = FindObjectOfType<AttackBoss> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Players")
		{
			//Active Rocket Boss
			ob.gameObject.SetActive (true);

	
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}


}
