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
				UserSingleton.Instance.FacebookID = obj["user_id"].Str;
				UserSingleton.Instance.FacebookAccessToken = obj["access_token"].Str;


				if(is_logged_in){

					JSONObject body = new JSONObject();
					body.Add("FacebookID", UserSingleton.Instance.FacebookID);
					body.Add("FacebookAccessToken", UserSingleton.Instance.FacebookAccessToken);
					body.Add("FacebookName", "Chris");
					body.Add("FacebookPhotoURL", "http://www/1.jpg");

					HTTPClient.Instance.POST("http://unity-action.azurewebsites.net/SignUp",
					                         body.ToString(),
					                         delegate(WWW response) 
					{

						Debug.Log (response.text);

						Application.LoadLevel("Game");

					});

				}



			});
		},delegate(bool isUnityShown) {

		},"");

	}
}
