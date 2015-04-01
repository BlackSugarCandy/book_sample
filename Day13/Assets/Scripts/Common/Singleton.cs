using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Boomlagoon.JSON;
using System;

public class Singleton : MonoBehaviour {

	public float aos_version = 1f, ios_version = 1f;
	
	public string HOST = "";
	public string CDN_CONFIG = "";

	public string AOSMarketURL = "market://details?id=com.nmedia.quiz";
	public string IOSMarketURL = "https://itunes.apple.com/app/id929061310?mt=8";

	public string LOGIN_HOST = "";

	public long FacebookUserID = 0;
	public string FacebookAccessToken = "";

	public JSONObject Language;
	public JSONObject Config;


	public bool StageStarted =false;

	public float Version {
		get {
#if UNITY_IPHONE
			return ios_version;
#else
			return aos_version;
#endif
		}
		set{
#if UNITY_IPHONE
			ios_version = value;
#else
			aos_version = value;
#endif
		}
	}

	public bool Initialized{
		get {
			return PlayerPrefs.GetInt("Initialized")==1;
		}
		set {
			PlayerPrefs.SetInt("Initialized",(value?1:0));
		}
	}

	public void Init()
	{
		InitLanguage();
		InitConfig();
		ios_version = (float)GetConfigDouble("ios_ver");
		aos_version = (float)GetConfigDouble("aos_ver");
#if UNITY_IPHONE
		CDN_CONFIG = GetConfig("ios");
#else
		CDN_CONFIG = GetConfig("android");
#endif

		//IAPSingleton.Instance.initializeIAP();

		if(Initialized == false){
			Initialized = true;
		}

	}

	
	public void InitConfig()
	{
		TextAsset txt = Resources.Load("Text/Config",typeof(TextAsset)) as TextAsset;
		//Debug.LogError(txt.text);
		Config = JSONObject.Parse(txt.text);
	}
	
	public string GetConfig(string key)
	{
		if(Language == null){
			InitConfig();
		}
		return Config.GetString(key);
	}
	
	public double GetConfigDouble(string key)
	{
		if(Language == null){
			InitConfig();
		}
		return Config.GetNumber(key);
	}

	
	public void InitLanguage()
	{
		TextAsset txt = Resources.Load("Text/Language",typeof(TextAsset)) as TextAsset;
		//Debug.LogError(txt.text);
		Language = JSONObject.Parse(txt.text);
	}
	
	public string GetLanguage(string key)
	{
		if(Language == null){
			InitLanguage();
		}
		return Language.GetString(key);
	}


	//Singleton Member And Method
	static Singleton _instance;
	public static Singleton Instance {
		get {
			if( ! _instance ) {
				GameObject container = new GameObject("Singleton");
				_instance = container.AddComponent( typeof( Singleton ) ) as Singleton;
				_instance.Init();
				DontDestroyOnLoad( container );
			}
			
			return _instance;
		}
	}
}
