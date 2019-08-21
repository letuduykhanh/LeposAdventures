using UnityEngine;
using System.Collections;

public class Reloadham4 : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Application.LoadLevel("ham4");
    }
}
