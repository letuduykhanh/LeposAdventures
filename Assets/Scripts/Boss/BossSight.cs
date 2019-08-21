using UnityEngine;
using System.Collections;

public class BossSight : MonoBehaviour {
    [SerializeField]
    private Boss boss;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Players") {
			boss.Target = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Players") {
			boss.Target = null;
        }
    }
}
