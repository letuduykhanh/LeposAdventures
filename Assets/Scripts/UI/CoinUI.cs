using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class CoinUI : MonoBehaviour
{
	private Animator anim;
	private float timer;
	public Text countText;
	public Text coinsText;
	public Text scoreText;
	public Text counterText;
	private int values;
	private int score;
	private int star;
	private int playerID;
	private int playercc;
	private int cointaglengh;
	private int scenelevel;
	private string scenename;
	private string[] id;
	private bool onetime;
	private bool vibration;
	private float seconds, minutes;
	private float timers;
	private InsertLevel insertlevel;
	private PlayerMovements player;
	public GameObject winisactive;
	public GameObject secondisactive;
	public GameObject thirdisactive;
	private GameObject[] coincount;
	private string android;
	private int bonusm = 0;
	private int coin;
	// Use this for initialization
	void Start ()
	{
		android = Application.persistentDataPath + "/save.txt";
		countText.text = "";
		coinsText.text = "";
		scoreText.text = "";
		coincount = GameObject.FindGameObjectsWithTag ("Coin");
		cointaglengh = coincount.Length;
		//print (cointaglengh);
		anim = GetComponent<Animator> ();
		insertlevel = GameObject.FindGameObjectWithTag ("Database").GetComponent<InsertLevel> ();
		player = GameObject.FindGameObjectWithTag ("Players").GetComponent<PlayerMovements> ();
		scenename = SceneManager.GetActiveScene ().name;
		string catnora = scenename.Substring (5, scenename.Length - 5);
		scenelevel = int.Parse (catnora);
		//print (scenelevel);
		if (System.IO.File.Exists (android)) {
			string info = System.IO.File.ReadAllText (android);
			id = info.Split (';');
			string stringvalues = id [2];
			playerID = int.Parse (stringvalues);
			//print (playerID);
		}
		onetime = true;
	}

	// Update is called once per frame
	void Update ()
	{
		countText.text = "" + values.ToString ();
		coinsText.text = "" + values.ToString ();

		if (vibration) {
			timer += Time.deltaTime;
		}
		if (timer >= 0.10f) {
			anim.SetBool ("Scale", false);
			vibration = false;
		}

		if (!player.clear) {
			CounterTime ();
		}
			
		if (winisactive.activeSelf && onetime) {
			StartCoroutine (chaichimnaydommauchiviyeuemchiviyeuem ());
			onetime = false;
		}
	}

	IEnumerator chaichimnaydommauchiviyeuemchiviyeuem ()
	{
		yield return new WaitForSeconds (0.5f);
		Rank (values, cointaglengh);
		yield return new WaitForSeconds (0.2f);
		if (minutes <= 2 && score >= 2000) {
			bonusm = 5000;
		}

		if (minutes <= 2 && score >= 1500 && score < 2000) {
			bonusm = 4000;
		}

		if (minutes <= 2 && score >= 1000 && score < 1500) {
			bonusm = 3000;
		}

		if (minutes <= 2 && score >= 500 && score < 1000) {
			bonusm = 2000;
		}

		if (minutes <= 2 && score >= 100 && score < 500) {
			bonusm = 1000;
		}

		int bonus = score + bonusm;
		scoreText.text = "" + bonus.ToString ();
		StartCoroutine (Starvalue (bonus));
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Coin c = other.GetComponent<Coin> ();
		if (other.tag == "Coin" && c.move) {
			values++;
			anim.SetBool ("Scale", true);
			vibration = true;
			timer = 0;
			Destroy (other.transform.parent.gameObject);
		}
	}

	void CounterTime ()
	{
		timers = Time.timeSinceLevelLoad;
		// Time.time la giay / 60 phut
		minutes = (int)(timers / 60f);
		// Time.time la giay chia lay du den 60/60 ko du nua thanh 00 lap lai
		seconds = (int)(timers % 60f);
		counterText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
	}

	void InserCurrrentLevel (int level, int star, int coins, string time, int score, int playerid)
	{
		StartCoroutine (insertlevel.Insertlevel (level, star, coins, time, score, playerid));
		onetime = false;
	}

	void Rank (int coincollected, int coinamount)
	{
		coin = (coincollected * 100) / coinamount;
//		print (coincollected + "" + coinamount);
//		print (coin);
		if (coin > 95 && coin <= 100) {
			score = 2200;
		} else if (coin > 95 && coin <= 100) {
			score = 2100;
		} else if (coin > 90 && coin <= 95) {
			score = 2000;
		} else if (coin > 85 && coin <= 90) {
			score = 1900;
		} else if (coin > 80 && coin <= 85) {
			score = 1800;
		} else if (coin > 75 && coin <= 80) {
			score = 1700;
		} else if (coin > 70 && coin <= 75) {
			score = 1600;
		} else if (coin > 65 && coin <= 70) {
			score = 1500;
		} else if (coin > 60 && coin <= 65) {
			score = 1400;
		} else if (coin > 55 && coin <= 60) {
			score = 1300;
		} else if (coin > 50 && coin <= 55) {
			score = 1200;
		} else if (coin > 45 && coin <= 50) {
			score = 1100;
		} else if (coin > 40 && coin <= 45) {
			score = 1000;
		} else if (coin > 35 && coin <= 40) {
			score = 900;
		} else if (coin > 30 && coin <= 35) {
			score = 800;
		} else if (coin > 25 && coin <= 30) {
			score = 700;
		} else if (coin > 20 && coin <= 25) {
			score = 600;
		} else if (coin > 15 && coin <= 20) {
			score = 500;
		} else if (coin > 10 && coin <= 15) {
			score = 400;
		} else if (coin > 5 && coin <= 10) {
			score = 300;
		} else if (coin > 1 && coin <= 5) {
			score = 200;
		} else if (coin == 1) {
			score = 100;
		} else {
			score = 0;
		}
	}

	IEnumerator Starvalue (int bonus)
	{
		if (coin >= 100) {
			star = 3;
			yield return new WaitForSeconds (0.2f);
			thirdisactive.SetActive (true);
			yield return new WaitForSeconds (0.2f);
			secondisactive.SetActive (true);
		} else if (coin >= 50 && coin < 100) {
			star = 2;
			yield return new WaitForSeconds (0.2f);
			thirdisactive.SetActive (true);
		} else if (coin < 50) {
			star = 1;
		}
		InserCurrrentLevel (scenelevel, star, values, counterText.text, bonus, playerID);
	}
}