using UnityEngine;
using System.Collections;

public class vach3dong : MonoBehaviour {

    public cua3 Cua3;
    // Use this for initialization
    void Start()
    {
        Cua3 = FindObjectOfType<cua3>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Players")
        {

            Cua3.MoCua3();



        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
