using UnityEngine;
using System.Collections;

public class CucGaidungyen : MonoBehaviour {
    public CucGai cucgai;
	// Use this for initialization
	void Start () {
        cucgai = FindObjectOfType<CucGai>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Players")
        {
            cucgai.dung();


        }
    }
}
