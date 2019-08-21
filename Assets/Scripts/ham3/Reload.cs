using UnityEngine;
using System.Collections;

public class Reload : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Application.LoadLevel("ham3");
    }
    
}
