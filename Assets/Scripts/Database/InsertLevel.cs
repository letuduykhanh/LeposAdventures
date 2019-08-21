using UnityEngine;
using System.Collections;

public class InsertLevel : MonoBehaviour
{

	//private string URL = "localhost/leposadventures/managerlevels.php";
	private string URL = "http://team14abcd.esy.es/managerlevels.php";
	private GetTotalStars gettotalstars;

	void Start ()
	{
		gettotalstars = GameObject.FindGameObjectWithTag ("Database").GetComponent<GetTotalStars> ();
	}

	public IEnumerator Insertlevel (int level, int star, int coin, string time, int score, int playerid)
	{
		//print (playerid);
		WWWForm form = new WWWForm ();
		form.AddField ("levelPost", level);
		form.AddField ("starPost", star);
		form.AddField ("coinPost", coin);
		form.AddField ("timePost", time);
		form.AddField ("scorePost", score);
		form.AddField ("playeridPost", playerid);
		WWW www = new WWW (URL, form);
		yield return new WaitForSeconds (1f);
		StartCoroutine (gettotalstars.GettotalStars (coin, playerid));
		if (www.isDone) {
			//string databaseString = www.text;
			//print (databaseString);
		}
	}
}
