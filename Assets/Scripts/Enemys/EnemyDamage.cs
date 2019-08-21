using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
	private int Enemys;
	public GameObject exploision;
	private EnemyMovements EMovements;
	private Animator anim;
	// Use this for initialization
	void Start ()
	{
		Enemys = 1;
		EMovements = GetComponent<EnemyMovements> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Enemys == 0) {
			IsDead ();
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Feets") {
			Takedamage (1);
		}
	}

	void ApplyDamage (int damage)
	{
		if (gameObject.tag == "Enemy") {
			Enemys = 0;
		}
	}

	void Takedamage (int damage)
	{
		gameObject.GetComponent<Collider2D> ().SendMessage ("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
	}

	public IEnumerator effect ()
	{
		Destroy (transform.parent.gameObject, 0.3f);
		yield return new WaitForSeconds (0.2f);
		Instantiate (exploision, gameObject.transform.position, gameObject.transform.rotation);

	}

	void IsDead ()
	{
		EMovements.dead = true;
		anim.SetBool ("Die", true);
	}

}
