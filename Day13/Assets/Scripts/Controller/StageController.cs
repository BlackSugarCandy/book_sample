using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageController : MonoBehaviour {

	public static StageController Instance;

	public int StagePoint = 0;

	public Text PointText;

	// Use this for initialization
	void Start () {

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
		
		DialogDataConfirm confirm = new DialogDataConfirm("Restart?", "Please press OK if you want to restart the game.", delegate(bool yn) {
			if(yn)
			{
				Debug.Log ("OK Pressed");
				Application.LoadLevel (Application.loadedLevel); // 
			}else{
				Debug.Log ("Cancel Pressed");
				Application.Quit();
			}
		});
		DialogManager.Instance.Push(confirm);
	}

}
