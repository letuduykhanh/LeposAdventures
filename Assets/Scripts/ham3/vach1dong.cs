using UnityEngine;
using System.Collections;

public class vach1dong : MonoBehaviour
{
    public cua1 Cua1;
    // Use this for initialization
    void Start()
    {
        Cua1 = FindObjectOfType<cua1>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Players")
        {

            Cua1.MoCua();
         


        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}