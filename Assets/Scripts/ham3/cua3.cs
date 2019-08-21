using UnityEngine;
using System.Collections;

public class cua3 : MonoBehaviour {
    public static cua3 door3;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void DongCua3()
    {
        StartCoroutine(Close());
    }
    public void MoCua3()
    {
        StartCoroutine(Open());
    }
    IEnumerator Close()
    {
        anim.SetBool("Close", true);
        yield return new WaitForSeconds(1);
        anim.Play("cua3dichuyen");
    }
    IEnumerator Open()
    {
        anim.SetBool("Close", false);
        yield return new WaitForSeconds(1);
        anim.Play("cua3");

    }

    void Update()
    {

    }
}
