using UnityEngine;
using System.Collections;

public class BaygaiDung : MonoBehaviour {
    public Baygai gai;
	// Use this for initialization
	void Start () {
        gai = FindObjectOfType<Baygai>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Players")
        {
            gai.dunglen();


        }
    }
}
