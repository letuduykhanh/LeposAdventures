using UnityEngine;
using System.Collections;

public class BossFire : MonoBehaviour
{

	public GameObject rocket;
	public GameObject rocket1;
	public GameObject rocket2;
	public GameObject rocket3;
	public GameObject rocket4;
	public GameObject rocket5;
	public GameObject rocket6;

	public GameObject explosion;
	public Action ac;

	// Use this for initialization
	void Start ()
	{
		ac = FindObjectOfType<Action> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Players") {
			ac.Fire ();

			//Active Rocket Boss
			rocket.gameObject.SetActive (true);
			rocket1.gameObject.SetActive (true);
			rocket2.gameObject.SetActive (true);
			rocket3.gameObject.SetActive (true);
			rocket4.gameObject.SetActive (true);
			rocket5.gameObject.SetActive (true);
			rocket6.gameObject.SetActive (true);

			//effect acttack
			explosion.gameObject.SetActive (true);
	

			Destroy (explosion.gameObject, 1);
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
