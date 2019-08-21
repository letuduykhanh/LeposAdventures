using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuUI : MonoBehaviour
{
	public GameObject summerlevels;
	public GameObject winterlevels;
	public GameObject seasonsgroup;
	public GameObject helppopup;
	public GameObject pausepopup;
	public GameObject pause;
	public GameObject winpopup;
	public GameObject ratingpopup;
	public GameObject turnoff;
	public GameObject turnon;
	private PlayerMovements player;
	private GetInfo getinfo;
	private string scenename;
	private int highscores;
	private bool onetime;
	private int unlock;
	private bool onoff;
	private int ahihi;
	private int level;
	// Use this for initialization
	void Start ()
	{
		GetSceneName ();
		player = GameObject.FindGameObjectWithTag ("Players").GetComponent<PlayerMovements> ();

		if (!scenename.Contains ("SelectSeasons") && !scenename.Contains ("Menu")) {
			if (AudioListener.volume == 1) {
				turn (false, true);
			} else {
				turn (true, false);
			}

			string nextlevel = scenename.Substring (5, scenename.Length - 5);
			level = int.Parse (nextlevel);
			//print (level);
			do {
				ahihi++;
			} while(ahihi <= level);
		}
	}

	public void NextLevel ()
	{
		string loading = "level" + ahihi;
		LoadScene (loading);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (player.clear) {
			onetime = true;
			if (onetime) {
				ShowWin ();
				onetime = false;
			}
		}


	}

	public void tutorial ()
	{
		LoadScene ("level20");
	}

	private void GetSceneName ()
	{
		scenename = SceneManager.GetActiveScene ().name;
	}

	private void LoadScene (string scene)
	{
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}

	// Main Menu //

	public void Play ()
	{
		timescaleone ();
		SceneManager.LoadScene ("SelectSeasons");
	}

	public void ShowHelp ()
	{
		helppopup.SetActive (true);
	}

	public void CloseHelp ()
	{
		helppopup.SetActive (false);
	}

	// Select seasons //

	public void Back ()
	{
		timescaleone ();
		SceneManager.LoadScene ("Menu");
	}

	public void SummerSelected ()
	{
		summerlevels.SetActive (true);
		seasonsgroup.SetActive (false);
	}

	public void CloseSummerlevels ()
	{
		summerlevels.SetActive (false);
		seasonsgroup.SetActive (true);
	}

	public void WinterSelected ()
	{
		winterlevels.SetActive (true);
		seasonsgroup.SetActive (false);
	}

	public void CloseWinterlevels ()
	{
		winterlevels.SetActive (false);
		seasonsgroup.SetActive (true);
	}

	// Pause Menu //

	public void ShowPause ()
	{
		timescalezero ();
		pause.SetActive (false);
		pausepopup.SetActive (true);
	}

	public void ClosePause ()
	{
		timescaleone ();
		pause.SetActive (true);
		pausepopup.SetActive (false);
	}

	public void Restart ()
	{
		timescaleone ();
		LoadScene (scenename);
	}

	private void timescaleone ()
	{
		Time.timeScale = 1;
	}

	private void timescalezero ()
	{
		Time.timeScale = 0;
	}

	// Win Menu //

	public void ShowWin ()
	{
		//timescalezero ();
		winpopup.SetActive (true);
		pause.SetActive (false);
	}

	public void CloseWin ()
	{
		LoadScene (scenename);
	}

	public void ShowRating ()
	{
		ratingpopup.SetActive (true);
	}

	public void CloseRating ()
	{
		ratingpopup.SetActive (false);
	}

	public void TurnOff ()
	{
		turn (false, true);
		AudioListener.volume = 1;
	}

	public void TurnOn ()
	{
		turn (true, false);
		AudioListener.volume = 0;

	}

	public void turn (bool one, bool two)
	{
		turnoff.SetActive (one);
		turnon.SetActive (two);
	}
		
}
