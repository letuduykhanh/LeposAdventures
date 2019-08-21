using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour {

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
			ac.Attack();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
