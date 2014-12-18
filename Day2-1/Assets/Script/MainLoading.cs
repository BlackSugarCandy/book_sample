using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class MainLoading : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Load ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Load()
	{
		
		TextAsset txt = Resources.Load("item_info",
		                               typeof(TextAsset)) as TextAsset;
		JSONArray json_array = JSONArray.Parse(txt.text); 
		for(int i = 0; i <json_array.Length ; i++){

			JSONObject obj = json_array[i].Obj;
			ItemInfo item_info = new ItemInfo(obj);
			Singleton.Instance.ItemInfoList.Add(item_info);

			Debug.Log (obj.ToString());

		}


	}
}
