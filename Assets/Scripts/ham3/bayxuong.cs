using UnityEngine;
using System.Collections;

public class bayxuong : MonoBehaviour {
    public bay trap;
    // Use this for initialization
    void Start () {
        trap = FindObjectOfType<bay>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Players")
        {
            trap.Bayxuong();


        }
    }
}
