using UnityEngine;
using System.Collections;

public class vunglen : MonoBehaviour {
    public static vunglen len;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Len1()
    {
        StartCoroutine(Up());
    }
    public void Xuong1()
    {
        StartCoroutine(Down());
    }
    IEnumerator Up()
    {
        anim.SetBool("Len", true);
        yield return new WaitForSeconds(1);
        anim.Play("vunglenlen");
    }
    IEnumerator Down()
    {
        anim.SetBool("Len", false);
        yield return new WaitForSeconds(1);
        anim.Play("vunglen");

    }
    void Update()
    {

    }
    
   

    
}
