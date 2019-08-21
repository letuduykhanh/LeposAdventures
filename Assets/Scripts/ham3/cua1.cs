using UnityEngine;
using System.Collections;

public class cua1 : MonoBehaviour {
    public static cua1 door1;
    private Animator anim;

    // Use this for initialization

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void DongCua()
    {
        StartCoroutine(Close());
    }
    public void MoCua()
    {
        StartCoroutine(Open());
    }
    IEnumerator Close()
    {
        anim.SetBool("Close",true);
        yield return new WaitForSeconds(1);
        anim.Play("Cua1dichuyen");
    }
    IEnumerator Open()
    {
        anim.SetBool("Close", false);
        yield return new WaitForSeconds(1);
        anim.Play("Cua1");
    }
    // Update is called once per frame
    void Update () {
	
	}
}
