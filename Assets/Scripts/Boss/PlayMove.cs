using UnityEngine;
using System.Collections;

public class PlayMove : MonoBehaviour {

	public Move_Up mu;
    // Use this for initialization
    void Start()
    {
		mu = FindObjectOfType<Move_Up>();
      
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Players")
        {
			mu.Len();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
