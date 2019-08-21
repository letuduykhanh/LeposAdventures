using UnityEngine;
using System.Collections;
using Facebook.Unity;
using UnityEngine.UI;


public class facebookManage : MonoBehaviour
{

	public Text score;

	void Start ()
	{
		if (score != null) {
			score.text = "";
		}
	}

	public Text userIDText;

	private void Awake ()
	{
		if (!FB.IsInitialized) {
			FB.Init ();
		} else {
			FB.ActivateApp ();
		}
	}

	public void LogIn ()
	{
		FB.LogInWithReadPermissions (callback: OnLogIn);
	}

	private void OnLogIn (ILoginResult result)
	{
		if (FB.IsLoggedIn) {
			AccessToken token = AccessToken.CurrentAccessToken;
			userIDText.text = token.UserId;
		} else
			Debug.Log ("Canceled Login");
	}

	public void Share ()
	{
		string myscore = score.text;
		FB.ShareLink (
			contentTitle: "My Scores: " + myscore,
			contentURL: new System.Uri ("http://kend.xxiv"),
			contentDescription: "Download FREE game Lepo's Adventure",
			callback: OnShare);
	}

	private void OnShare (IShareResult result)
	{
		if (result.Cancelled || !string.IsNullOrEmpty (result.Error)) {
			Debug.Log ("ShareLink error: " + result.Error);
		} else if (!string.IsNullOrEmpty (result.PostId)) {
			Debug.Log (result.PostId);
		} else
			Debug.Log ("Share succeed");
	}
}
