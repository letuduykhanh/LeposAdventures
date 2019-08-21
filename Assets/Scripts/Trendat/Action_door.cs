using UnityEngine;
using System.Collections;

public class Action_door : MonoBehaviour {
	private Animator MyAnimator;
	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator>();
	}

	public void doorclose(){
		MyAnimator.SetTrigger ("close");
	} 
	
	// Update is called once per frame
	void Update () {
	
	}
}
