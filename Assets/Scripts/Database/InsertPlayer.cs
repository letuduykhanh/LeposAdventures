using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System.Collections;

public class InsertPlayer : MonoBehaviour
{
	public GameObject inputField;
	public GameObject entername;
	public GameObject exists;
	public GameObject okpopup;
	public GameObject wait;
	private string paths;
	private InputField getText;
	private string databaseString;
	//private string URL = "localhost/leposadventures/managerplayers.php";
	private string URL = "http://team14abcd.esy.es/managerplayers.php";
	private string android;
	// Use this for initialization
	void Start ()
	{
		android = Application.persistentDataPath + "/save.txt";
		if (!System.IO.File.Exists (android)) {
			entername.SetActive (true);
		}

		print (Application.persistentDataPath);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void OK ()
	{
		inputField = GameObject.FindGameObjectWithTag ("InputField");
		getText = inputField.GetComponent<InputField> ();
		StartCoroutine (SelectPlayerId (getText.text));
		Cancel ();
	}

	public void Cancel ()
	{
		wait.SetActive (true);
		entername.SetActive (false);
	}

	public IEnumerator UpdatePlayer (int star, int coin, int id)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("namePost", 0);
		form.AddField ("starPost", star);
		form.AddField ("coinPost", coin);
		form.AddField ("playeridPost", id);
		form.AddField ("updatePost", "true");
		WWW database = new WWW (URL, form);
		yield return new WaitForSeconds (2f);
		if (database.isDone) {
			databaseString = database.text;
			//print (databaseString);
			if (databaseString.Equals ("Exists")) {
				print ("ten da ton tai");
			} else {

			}

		}

	}

	public void closeexist ()
	{
		exists.SetActive (false);
		entername.SetActive (true);
	}

	public void closeok ()
	{
		okpopup.SetActive (false);
	}

	IEnumerator SelectPlayerId (string name)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("namePost", name);
		form.AddField ("starPost", 0);
		form.AddField ("coinPost", 0);
		form.AddField ("playeridPost", 0);
		form.AddField ("updatePost", "false");
		WWW database = new WWW (URL, form);
		yield return new WaitForSeconds (2f);
		if (database.isDone) {
			databaseString = database.text;
			//print (databaseString);
			if (databaseString.Equals ("Exists")) {
				wait.SetActive (false);
				exists.SetActive (true);
			} else {
				wait.SetActive (false);
				okpopup.SetActive (true);
				Writetext (getText.text, databaseString, "0", "0");
			}

		} else {
		}

	}

	public void Writetext (string name, string data, string star, string coin)
	{
		android = Application.persistentDataPath + "/save.txt";
		System.IO.File.WriteAllText (android, "Yes;" + name + ";" + data + ";" + star + ";" + coin, Encoding.ASCII);
	}

}
