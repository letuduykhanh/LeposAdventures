using UnityEngine;
using System.Collections;


public class BossRocket : MonoBehaviour {


	private float speed = 5f;

	private Rigidbody2D myRigi;

	private Vector2 direction;

	// Use this for initialization
	void Start () {
		myRigi = GetComponent<Rigidbody2D>();
		direction = Vector2.up;
	}

	// Update is called once per frame
	void FixedUpdate () {
		myRigi.velocity = direction * speed;
	}

	public void Initialize(Vector2 direction){
		this.direction = direction;
	}

	void OnBecameInvisible() {
		Destroy(gameObject);
	}

}
