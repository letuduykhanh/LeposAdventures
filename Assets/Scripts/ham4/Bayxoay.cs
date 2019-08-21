using UnityEngine;
using System.Collections;

public class Bayxoay : MonoBehaviour {
    private Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void dichuyen()
    {
        anim.Play("trapdichuyen2");
    }
}
