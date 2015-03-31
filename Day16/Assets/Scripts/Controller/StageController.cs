using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Boomlagoon.JSON;
using System.Collections.Generic;

public class StageController : MonoBehaviour {

	public static StageController Instance;

	public int StagePoint = 0;

	public Text PointText;

	// Use this for initialization
	void Start () {
		
		SignIn ();

		Instance = this;
		DialogDataAlert alert = new DialogDataAlert("START", "Game Start!", delegate() {
			Debug.Log ("OK Pressed");
		});

		DialogManager.Instance.Push(alert);

	}

	public void AddPoint(int Point)
	{
		StagePoint += Point;
		PointText.text = StagePoint.ToString();
	}

	public void FinishGame()
	{
		Dictionary<string, string> param = new Dictionary<string, string>();
		param.Add("UserID", "9876");
		param.Add("Point", StagePoint.ToString());
		
		HTTPClient.Instance.POST (
			"http://unity-action.azurewebsites.net//UpdateResult",
			param,
			delegate(WWW obj) {
			JSONObject json = JSONObject.Parse(obj.text);
			Debug.Log("Response is : " + json.ToString());

			GetRanking();

		});

	}

	private void SignIn(){

		Dictionary<string, string> param = new Dictionary<string, string>();
		param.Add("FacebookID", "9876");
		param.Add("FacebookName", "Chris");
		param.Add("FacebookPhotoURL", "http://www/1.jpg");
		
		HTTPClient.Instance.POST (
			"http://unity-action.azurewebsites.net//Login",
			param,
			delegate(WWW obj) {
			JSONObject json = JSONObject.Parse(obj.text);
			Debug.Log("Response is : " + json.ToString());
		}
		);

	}

	// Get Ranking list From server
	private void GetRanking(){
		HTTPClient.Instance.GET (
			"http://unity-action.azurewebsites.net//Total/1/50",
			new Dictionary<string, string>(),
			delegate(WWW obj) {
				
				// Dialog Push
				JSONArray jarr = JSONArray.Parse(obj.text);
			
				string rankings = "";
				for(int i=0;i<jarr.Length;i++){
					rankings += jarr[i].Obj.GetString("Rank") + ". " + jarr[i].Obj.GetString("FacebookName") + " \t\tscore :" + jarr[i].Obj.GetString("Point") + "\n\n";
				}
				
				DialogDataRanking ranking = new DialogDataRanking("Game Over", StagePoint, rankings, delegate(bool yn) {
					if(yn)
					{
						Debug.Log ("OK Pressed");
						Application.LoadLevel (Application.loadedLevel); // 
					}else{
						Debug.Log ("Cancel Pressed");
						Application.Quit();
					}
				});
				DialogManager.Instance.Push(ranking);
			}
		);

	}

}
