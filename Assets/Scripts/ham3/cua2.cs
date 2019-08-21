using UnityEngine;
using System.Collections;

public class cua2 : MonoBehaviour {
    public static cua2 door2;
    private Animator anim;

    // Use this for initialization

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void DongCua2()
    {
        StartCoroutine(Close());
    }
    public void MoCua2()
    {
        StartCoroutine(Open());
    }
    IEnumerator Close()
    {
        anim.SetBool("Close", true);
        yield return new WaitForSeconds(1);
        anim.Play("Cua2dichuyen");
    }
    IEnumerator Open()
    {
        anim.SetBool("Close", false);
        yield return new WaitForSeconds(1);
        anim.Play("Cua2");
    }
    void Update()
    {

    }
}
