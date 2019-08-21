using UnityEngine;
using System.Collections;

public class vach2 : MonoBehaviour {
    public cua2 Cua2;
    // Use this for initialization
    void Start () {
        Cua2 = FindObjectOfType<cua2>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Players")
        {
            Cua2.DongCua2();


        }
    }
}

