using UnityEngine;
using System.Collections;

public class EnemyMovements : MonoBehaviour
{
	
	private Animator anim;
	private Rigidbody2D rb2d;
	public float speed = 2.0f;
	public bool walk;
	public bool run;
	private bool attack;
	private bool walktmp;
	private bool runtmp;
	public bool dead;
	public Transform point;
	public LayerMask onlyGroundMask;
	private float flip;
	private bool grounded;
	private EnemyDamage enemydamage;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		enemydamage = gameObject.GetComponent<EnemyDamage> ();
		walktmp = walk;
		runtmp = run;
		AnimWR ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		flip = transform.localScale.x;
		if (grounded) {
			if (flip > 0 && run && !walk && !attack && !dead) {
				MoveandRun (-speed);
			} else if (flip < 0 && run && !walk && !attack && !dead) {
				MoveandRun (speed);
			} else if (flip > 0 && !run && walk && !attack && !dead) {
				MoveandRun (-speed * 0.5f);
			} else if (flip < 0 && !run && walk && !attack && !dead) {
				MoveandRun (speed * 0.5f);
			}
		}

	}

	void OnBecameVisible ()
	{
		enabled = true;
	}

	void OnBecameInvisible ()
	{
		enabled = false;
	}

	void FixedUpdate ()
	{
		// Check đã chạm đất chưa
		grounded = Physics2D.OverlapCircle (point.position, 0.2f, onlyGroundMask);
	}

	void MoveandRun (float speed)
	{
		rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
	}

	void AnimWR ()
	{
		if (run && !walk) {
			anim.SetBool ("Run", run);
		} else if (!run && walk) {
			anim.SetBool ("Walk", walk);
		}
	}

	void OnCollisionStay2D (Collision2D other)
	{
		if (other.collider.tag == "Players") {
			attack = true;
			anim.SetBool ("Attack", attack);
			if (run && !walk) {
				anim.SetBool ("Run", false);
			} else if (!run && walk) {
				anim.SetBool ("Walk", false);
			}
		}
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if (other.collider.tag == "Players") {
			attack = false;
			anim.SetBool ("Attack", attack);
			if (runtmp && !walktmp) {
				anim.SetBool ("Run", runtmp);
			} else if (!runtmp && walktmp) {
				anim.SetBool ("Walk", walktmp);
			}
		}
	}

	void Flip ()
	{
		transform.localScale = transform.localScale.x == -0.3f ? new Vector2 (0.3f, 0.3f) : new Vector2 (-0.3f, 0.3f);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Feets") {
			dead = true;
			anim.SetBool ("Die", true);
			StartCoroutine (enemydamage.effect ());
		}

		if (other.tag == "EnemyWall") {
			Flip ();
		}
	}
}
