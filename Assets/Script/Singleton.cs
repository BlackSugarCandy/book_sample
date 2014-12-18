using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Boomlagoon.JSON;

public class Singleton : MonoBehaviour {

	public List<ItemInfo> ItemInfoList;

	public void Init()
	{
		ItemInfoList = new List<ItemInfo>();


	}

	//Singleton Member And Method
	static Singleton _instance;
	public static Singleton Instance {
		get {
			if( ! _instance ) {
				GameObject container = new GameObject("Singleton");
				_instance = container.AddComponent( typeof( Singleton ) ) as Singleton;
				DontDestroyOnLoad( container );
				_instance.Init();
			}
			return _instance;        
		}
	}

}