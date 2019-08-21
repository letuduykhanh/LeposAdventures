using UnityEngine;
using System.Collections;

public class BossFire2 : MonoBehaviour {

	public GameObject trap;
	public GameObject trap1;
	public GameObject trap2;
	public GameObject trap3;


	public GameObject explosion;
	public Action ac;
	// Use this for initialization
	void Start()
	{
		ac = FindObjectOfType<Action>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Players")
		{
			ac.Fire();
			//effect acttack
			explosion.gameObject.SetActive (true);

			//Active Rocket Boss
			trap.gameObject.SetActive (true);
			trap1.gameObject.SetActive (true);
			trap2.gameObject.SetActive (true);
			trap3.gameObject.SetActive (true);

			Destroy (gameObject);
			Destroy (explosion.gameObject,1);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
