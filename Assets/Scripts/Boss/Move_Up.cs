using UnityEngine;
using System.Collections;

public class Move_Up : MonoBehaviour
{
	private Animator MyAnimator;
	// Use this for initialization
	void Start ()
	{
		MyAnimator = GetComponent<Animator> ();
	}

	public void Len ()
	{
		MyAnimator.SetTrigger ("Up");
		MyAnimator.Play ("Captreo_Up");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
