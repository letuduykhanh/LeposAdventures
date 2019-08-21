using UnityEngine;
using System.Collections;

public class SplashScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Change ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Change()
	{
		StartCoroutine(Splash());
	}
	IEnumerator Splash()
	{
		yield return new WaitForSeconds(2);
		Application.LoadLevel("Menu");
	}
}
