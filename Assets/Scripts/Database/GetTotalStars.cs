using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;

public class GetTotalStars : MonoBehaviour
{
	private int staramount;
	//private string URL = "localhost/leposadventures/gettotalstars.php";
	private string URL = "http://team14abcd.esy.es/gettotalstars.php";
	private InsertPlayer insertplayer;
	private int coinint;
	private string android;

	void Start ()
	{
		insertplayer = GameObject.FindGameObjectWithTag ("Database").GetComponent<InsertPlayer> ();
	}

	public IEnumerator GettotalStars (int coin, int playerid)
	{
		android = Application.persistentDataPath + "/save.txt";
		WWWForm form = new WWWForm ();
		form.AddField ("playeridPost", playerid);
		WWW www = new WWW (URL, form);
		yield return new WaitForSeconds (2f);
		if (www.isDone) {
			string databaseString = www.text.ToString ();
			staramount = int.Parse (databaseString);
			if (System.IO.File.Exists (android)) {
				string info = System.IO.File.ReadAllText (android);
				string[] stringarray = info.Split (';');
				string getcoin = stringarray [4];
				if (int.TryParse (getcoin, out coinint)) {
					coinint = coinint + coin;
					print (coin);
					insertplayer.Writetext (stringarray [1], stringarray [2], databaseString, coinint.ToString ());
					yield return new WaitForSeconds (1f);
					StartCoroutine (insertplayer.UpdatePlayer (staramount, coinint, playerid));
				} else {
					//print (false);
				}
			}
		} else {
		}
	}
}
