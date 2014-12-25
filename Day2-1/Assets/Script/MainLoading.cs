using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class MainLoading : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Load ();

		PrintItem();

		PrintList();

		SortList();
		
		PrintList();

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

	public void PrintItem()
	{

		ItemInfo item1 = Singleton.Instance.ItemInfoList.Find(x=>x.item_info_id == 1);

		Debug.Log("name : " + item1.name);


	}

	public void PrintList()
	{
		foreach(var item in Singleton.Instance.ItemInfoList){
			Debug.Log (item.name);
		}
	}

	public void SortList()
	{
		Singleton.Instance.ItemInfoList.Sort(delegate(ItemInfo x, ItemInfo y) {
			if(x.item_info_id < y.item_info_id) return -1;
			else if(x.item_info_id > y.item_info_id) return 1;
			else return 0;
		});

	}

}
