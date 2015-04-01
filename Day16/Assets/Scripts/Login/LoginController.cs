using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;
using System;

public class LoginController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoginFacebook()
	{
		FB.Init(delegate {
			FB.Login("",delegate(FBResult result) {


				Debug.Log (result.Text);
				JSONObject obj = JSONObject.Parse(result.Text);
				bool is_logged_in = obj["is_logged_in"].Boolean;
				Singleton.Instance.FacebookUserID = long.Parse(obj["user_id"].Str);
				Debug.Log("FacebookUserID : " + Singleton.Instance.FacebookUserID);
				Singleton.Instance.FacebookAccessToken = obj["access_token"].Str;
				Debug.Log("FacebookAccessToken : " + Singleton.Instance.FacebookAccessToken);
				if(is_logged_in){
					Application.LoadLevel("Game");
				}



			});
		},delegate(bool isUnityShown) {

		},"");

	}
}
