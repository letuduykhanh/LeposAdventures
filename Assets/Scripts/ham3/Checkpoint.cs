using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
    public LevelManager levelManager;

 
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

  
    void Update()
    {
        //Vector3 thePosition = transform.localPosition;
        //thePosition.z = 10;
        //transform.localPosition = thePosition;
    }

    // Khi người chơi chạy tới điểm Checkpoint thì sẽ lưu lại ở đó 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            levelManager.currentCheckpoint = gameObject;

            Debug.Log("Activated Checkpoint " + transform.position);
        }
    }
}
