using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class BossObstacles : MonoBehaviour {

	private float speed = 4f;

	private Rigidbody2D myRigi;

	private Vector2 direction;

	// Use this for initialization
	void Start () {
		myRigi = GetComponent<Rigidbody2D>();
		direction = Vector2.right;
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
