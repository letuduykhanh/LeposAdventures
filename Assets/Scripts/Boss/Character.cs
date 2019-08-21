using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour {

	[SerializeField]
	protected Stat healthStat;

	public abstract bool IsDead { get; }

	protected bool facingRight;

	public bool Attack { get; set; }

	public bool TakingDamage { get; set; }

	[SerializeField]
	private List<string> damageSourges;

	public Animator MyAnimator { get; private set; }

	// Use this for initialization
	public virtual void Start ()
	{
		facingRight = true;
		MyAnimator = GetComponent<Animator> ();	
		healthStat.Initialize ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public abstract IEnumerator TakeDamage ();

	public virtual void ChangeDirection ()
	{		
		facingRight = !facingRight;
		transform.localScale = new Vector3 (transform.localScale.x * -1, 1, 1);
	}
		
	public virtual void OnTriggerEnter2D (Collider2D other)
	{
		if (damageSourges.Contains (other.tag)) {
			StartCoroutine (TakeDamage ());
		}
	}
}
