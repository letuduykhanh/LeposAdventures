using UnityEngine;
using System.Collections;

public class vach1 : MonoBehaviour {
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
               Cua1.DongCua();
               

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
