using UnityEngine;
using System.Collections;

public class bay : MonoBehaviour {
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
	void Update () {
	}
    public void Baylen()
    {
        StartCoroutine(Up());
    }
    public void Bayxuong()
    {

        StartCoroutine(Down());

    }
    IEnumerator Up()
    {
        anim.SetBool("Len", true);
        yield return new WaitForSeconds(1);
        anim.Play("gai2");
    }
    IEnumerator Down()
    {
        anim.SetBool("Len", false);
        yield return new WaitForSeconds(1);
        anim.Play("gai1");
    }
}
