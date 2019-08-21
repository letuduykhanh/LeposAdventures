using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Loading2 : MonoBehaviour
{
	AsyncOperation ao;
   
	public GameObject Background;
	public Image Loadingbar;
	public Text percent;
	public Text phantram;
	public Text load;
	public Image Logo;
	public bool isFakeLoadingBar = false;
	public float fakeIncrement = 0f;
	public float fakeTiming = 0f;
	// Use this for initialization
	void Start ()
	{
		Loadingbar.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		percent.text = (Loadingbar.fillAmount * 100).ToString ("f0");
	}

	public void loadlevel ()
	{
		string buttonname = EventSystem.current.currentSelectedGameObject.name;
		LoadLevel (buttonname);
	}

	public void LoadLevel (string scene)
	{
		Background.SetActive (true);
		Loadingbar.gameObject.SetActive (false);
		phantram.gameObject.SetActive (true);
		load.gameObject.SetActive (true);
		Logo.gameObject.SetActive (true);
		percent.gameObject.SetActive (true);
        
		if (!isFakeLoadingBar) {
			StartCoroutine (LoadLevelWithRealProgress (scene));
		} else {
			StartCoroutine (LoadLevelWithFakeProgress (scene));
		}
	}

	IEnumerator LoadLevelWithRealProgress (string scene)
	{
		yield return new WaitForSeconds (1);
	
		ao = SceneManager.LoadSceneAsync (scene);
		ao.allowSceneActivation = false;
	
		while (!ao.isDone) {
			Loadingbar.fillAmount = ao.progress;
			if (ao.progress == 0.9f) {
				Loadingbar.fillAmount = 1f;
				ao.allowSceneActivation = true;
			}
			//Debug.Log (ao.progress);
			yield return null;
		}
	}

	IEnumerator LoadLevelWithFakeProgress (string scene)
	{
		yield return new WaitForSeconds (1);
		while (Loadingbar.fillAmount != 1f) {
			Loadingbar.fillAmount += fakeIncrement;
			yield return new WaitForSeconds (fakeTiming);
		}
		while (Loadingbar.fillAmount == 1f) {
			SceneManager.LoadScene (scene);
			yield return null;
		}
	}
}
