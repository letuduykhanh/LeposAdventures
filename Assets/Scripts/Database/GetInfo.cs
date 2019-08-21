using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetInfo : MonoBehaviour
{
	private string[] id;
	private int playerID;
	public Text starvalue;
	public Text coinvalue;
	public GameObject springlock;
	public GameObject springplay;
	public GameObject autumnlock;
	public GameObject autumnplay;
	public GameObject winterlock;
	public GameObject winterplay;
	private int totalstar;
	private string android;

	void Start ()
	{
		android = Application.persistentDataPath + "/save.txt";

		if (System.IO.File.Exists (android)) {
			string info = System.IO.File.ReadAllText (android);
			id = info.Split (';');
			Getinfo ();

			string starsvalues = id [3];
			if (int.TryParse (starsvalues, out totalstar)) {

				if (totalstar >= 18) {
					springplay.SetActive (true);
					springlock.SetActive (false);
				}
				if (totalstar >= 36) {
					autumnplay.SetActive (true);
					autumnlock.SetActive (false);
				}
				if (totalstar >= 54) {
					winterplay.SetActive (true);
					winterlock.SetActive (false);
				}
				//print (totalstar);
			}
		}
	}

	void Getinfo ()
	{
		if (System.IO.File.Exists (android)) {
			string infostring = System.IO.File.ReadAllText (android);
			string[] stringarray = infostring.Split (';');
			starvalue.text = stringarray [3];
			coinvalue.text = stringarray [4];
		}
	}
}
