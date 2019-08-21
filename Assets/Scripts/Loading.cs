using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
	public float loadingTime;
	public Image loadingBar;
	public Text percent;
	// Use this for initialization
	void Start ()
	{
		loadingBar.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (loadingBar.fillAmount <= 1) {
			loadingBar.fillAmount += 1.0f / loadingTime * Time.deltaTime;
		}
		if (loadingBar.fillAmount == 1.0f) {
			SceneManager.LoadScene ("ham4");
		}
		percent.text = (loadingBar.fillAmount * 100).ToString ("f0");
	}
}
