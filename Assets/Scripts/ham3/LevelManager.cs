using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    public PlayerMovements player;
  
    void Start()
    {
        player = FindObjectOfType<PlayerMovements>();
    }

   
    void Update()
    {

    }

    //Hồi sinh nhân vật
    public void RespawnPlayer()
    {
        player.transform.position = currentCheckpoint.transform.position;
        Vector3 theScale = player.transform.localScale;
        theScale.x = 0.2f;
        player.transform.localScale = theScale;
        Debug.Log("Player Respawn");
    }
}
