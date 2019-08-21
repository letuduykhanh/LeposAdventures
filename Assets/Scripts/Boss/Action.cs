using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour {
	 private Animator MyAnimator;
	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator>();
	}
		
	// Update is called once per frame
	public void Attack(){
		
			MyAnimator.SetTrigger ("attack");
	}

	public void Fire(){

		MyAnimator.SetTrigger ("throw");
	} 
		
		
	void Update () {
	
	}
}
