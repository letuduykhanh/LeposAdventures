using UnityEngine;
using System.Collections;

public class Bayxoaydichuyen : MonoBehaviour {
    public Bayxoay xoay;
	// Use this for initialization
	void Start () {
        xoay = FindObjectOfType<Bayxoay>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Players")
        {
            xoay.dichuyen();


        }
    }
}
