using UnityEngine;
using System.Collections;

public class vunglenlen : MonoBehaviour {
    public vunglen len;
	// Use this for initialization
	void Start () {
        len = FindObjectOfType<vunglen>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Players")
        {
            len.Len1();


        }
    }
}
