using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Player
{
	public string username;
	public string scores;
	public string time;
}

public class Rating : MonoBehaviour
{
	public GameObject samplebutton;
	public Transform contentPanel;
	private List<Player> playerList;
	private List<string> namestring;
	private List<string> scorestring;
	private List<string> timestring;
	//private string URL = "localhost/leposadventures/rating.php";
	private string URL = "http://team14abcd.esy.es/rating.php";
	// Use this for initialization
	void Start ()
	{
		StartCoroutine (GetList ());
	}

	public IEnumerator GetList ()
	{
		WWW www = new WWW (URL);
		yield return new WaitForSeconds (2f);
		if (www.isDone) {
			namestring = new List<string> ();
			scorestring = new List<string> ();
			timestring = new List<string> ();
			string databaseString = www.text;
			string[] longstring = databaseString.Split ('\n');
			for (int i = 0; i < longstring.Length - 1; i++) {
				string[] splitstring = longstring [i].Split (';');
				namestring.Add (splitstring [0]);
				scorestring.Add (splitstring [1]);
				timestring.Add (splitstring [2]);
			}

			for (int i = 0; i < namestring.Count; i++) {
				GameObject newButton = Instantiate (samplebutton) as GameObject;
				Template template = newButton.GetComponent<Template> ();
				template.playersname.text = namestring [i];
				template.playerscore.text = scorestring [i];

				if (i == 0) {
					template.trophy [0].SetActive (true);
				} else if (i == 1) {
					template.trophy [1].SetActive (true);
				} else if (i == 2) {
					template.trophy [2].SetActive (true);
				}

				if (i > 2) {
					template.playerstime.text = (i + 1).ToString ();
				}

				newButton.transform.SetParent (contentPanel);
			}
		}
	}
}
